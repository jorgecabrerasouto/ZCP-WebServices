using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZCPWebServices.Data;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        //Refresh tokens
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context,
            IConfiguration configuration,
            TokenValidationParameters tokenValidationParameters)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;

            //Refresh tokens
            _tokenValidationParameters = tokenValidationParameters;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterVM payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Por favor ingrese todos los datos requeridos!");
            }

            var userExists = await _userManager.FindByEmailAsync(payload.Email);

            if (userExists != null)
            {
                return BadRequest($"El Usuario {payload.Email} ya existe!");
            }

            ApplicationUser newUser = new()
            {
                Email = payload.Email,
                UserName = payload.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, payload.Password);

            if (!result.Succeeded)
            {
                return BadRequest($"No se pudo crear el Usuario {payload.UserName}!");
            }
            
            switch (payload.Role)
            {
                case "Admin":
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);
                    break;
                default:
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                    break;
            }            
            
            return Created(nameof(Register), $"Se creó el Usuario {payload.Email}!");
        }

        [HttpPost("login-user")]
       
        public async Task<IActionResult> Login([FromBody] LoginVM payload)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Por favor, ingrese todos los campos requeridos");
            }

            var user = await _userManager.FindByEmailAsync(payload.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, payload.Password))
            {
                var tokenValue = await GenerateJwtTokenAsync(user, "");

                //return Ok(tokenValue);

                var expiresInSeconds = int.Parse(_configuration["JWT:ExpiresInMinutes"]) * 60;
                var respuestaWebApiToken = new { statusCode = 200, accessToken = tokenValue.Token, expiresIn = expiresInSeconds, tokenType = "bearer" };

                return Ok(respuestaWebApiToken);
            }

            var respuestaWebApiNoAutenticado = new { statusCode = 401, error = "Unauthorized", message = "El cliente no pudo ser autenticado" };
            
            return Unauthorized(respuestaWebApiNoAutenticado);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetCredentials([FromBody] TokenOauthVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Por favor, ingrese todos los campos requeridos");
            }

            var mensaje = "";

            if (request == null || string.IsNullOrEmpty(request.client_id))
            {
                mensaje = "El campo client_id es requerido";
            }

            if (string.IsNullOrEmpty(request.client_secret))
            {
                mensaje += " - El campo client_secret es requerido";
            }

            if (mensaje != "")
            {
                return BadRequest(mensaje);
            }

            var user = await _userManager.FindByNameAsync(request.client_id);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.client_secret))
            {
                var tokenValue = await GenerateJwtTokenAsync(user, "");

                var expiresInSeconds = int.Parse(_configuration["JWT:ExpiresInMinutes"]) * 60;

                var respuestaWebApiToken = new { statusCode = 200, accessToken = tokenValue.Token, expiresIn = expiresInSeconds, tokenType = "bearer" };

                return Ok(respuestaWebApiToken);
            }

            var respuestaWebApiOauth = new { statusCode = 401, error = "Unauthorized", message = "El cliente no pudo ser autenticado" };

            return Unauthorized(respuestaWebApiOauth);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenRequestVM payload)
        {
            try
            {
                var result = await VerifyAndGenerateTokenAsync(payload);
                
                if (result == null) return BadRequest("Tokens inválidos");

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
        private async Task<AuthResultVM> VerifyAndGenerateTokenAsync(TokenRequestVM payload)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                // Check 1 - Check JWT token format
                var tokenInVerification = jwtTokenHandler.ValidateToken(payload.Token, _tokenValidationParameters, out var validatedToken);

                //Check 2 - Emcription algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false) return null;
                }

                //Check 3 - validatedToken expire date
                var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTimeInUTC(utcExpiryDate);
                if (expiryDate > DateTime.UtcNow) throw new Exception("El token no ha expirado aún!");

                //Check 4 - Refresh token Existe en la base de datos
                var dbRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(n => n.Token == payload.RefreshToken);
                if (dbRefreshToken == null) throw new Exception("El refresh token no existe en nuestra base de datos");
                else
                {
                    //Check 5 - Validate Id
                    var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

                    if (dbRefreshToken.JwtId != jti) throw new Exception("El refresh token no concuerda");

                    //Check 6 - Refresh token expiration

                    if (dbRefreshToken.DateExpire <= DateTime.UtcNow) throw new Exception("Su refresh token ha caducado, por favor ingrese nuevamente!");

                    //Check 7 - Refresh token revoked

                    if (dbRefreshToken.IsRevoked) throw new Exception("Su refresh token ha sido revocado");

                    // Generar nuevo token (con el reefresh tocken existente)
                    var dbUserData = await _userManager.FindByIdAsync(dbRefreshToken.UserId);
                    var newTokenResponse = GenerateJwtTokenAsync(dbUserData, payload.RefreshToken);

                    return await newTokenResponse;
                }
            }
            catch (SecurityTokenExpiredException)
            {
                var dbRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(n => n.Token == payload.RefreshToken);
                // Generate new token (with existing refresh token)
                var dbUserData = await _userManager.FindByIdAsync(dbRefreshToken.UserId);
                var newTokenResponse = GenerateJwtTokenAsync(dbUserData, payload.RefreshToken);

                return await newTokenResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        private async Task<AuthResultVM> GenerateJwtTokenAsync(ApplicationUser user, string existingRefreshToken)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Add User Roles
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JWT:ExpiresInMinutes"])), 
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = new RefreshToken();

            if(string.IsNullOrEmpty(existingRefreshToken))
            {
                refreshToken = new RefreshToken()
                {
                    JwtId = token.Id,
                    IsRevoked = false,
                    UserId = user.Id,
                    DateAdded = DateTime.UtcNow,
                    DateExpire = DateTime.UtcNow.AddMonths(6),
                    Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString()
                };
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
            }


            var response = new AuthResultVM()
            {
                Token = jwtToken,
                RefreshToken = (string.IsNullOrEmpty(existingRefreshToken)) ? refreshToken.Token : existingRefreshToken,
                ExpiresAt = token.ValidTo
            };

            return response;
        }

        private DateTime UnixTimeStampToDateTimeInUTC(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp);
            return dateTimeVal;
        }

    }
}
