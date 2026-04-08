using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("/consulta")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class BaseZcpController : ControllerBase
    {
        private BaseZcpsService _baseZcpService;

        public BaseZcpController(BaseZcpsService baseZcpService)
        {
            _baseZcpService = baseZcpService;
        }

        [HttpPost("add-consulta-de-zcp")]
        public IActionResult AddBaseZcp([FromBody] Data.ViewModels.BaseZcpsVM baseZcp)
        {
            _baseZcpService.AddBaseZcp(baseZcp);
            return Ok();
        }

        [HttpGet("zcp")]
        public IActionResult GetAllBaseZcpsFromView(int page, int perPage)
        {
            if (page <= 0 || perPage <= 0)
            {
                var respuestaWebApiBadRequest = new { statusCode = 400, error = "Bad Request", message = "Los parámetros 'page' y 'perPage' deben ser números enteros positivos." };

                return Ok(respuestaWebApiBadRequest);
            }

            try
            {
                List<Data.Models.BaseZcp> allBaseZcp = _baseZcpService.GetAllBaseZcp(page, perPage);
                if (!allBaseZcp.Any())
                {
                    var respuestaWebApiNoExist = new { statusCode = 404, error = "Not Found", message = "No existen registros que cumplan los parametros dados" };

                    return NotFound(respuestaWebApiNoExist);
                }

                var respuestaWebApiOk = new { statusCode = 200, data = allBaseZcp };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
