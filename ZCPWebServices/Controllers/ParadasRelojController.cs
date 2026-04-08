using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("/consulta")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class ParadasRelojController : ControllerBase
    {
        private ParadasRelojService _paradasRelojService;

        public ParadasRelojController(ParadasRelojService paradasRelojService)
        {
            _paradasRelojService = paradasRelojService;
        }

        [HttpPost("add-parada-reloj")]
        public IActionResult AddParadaReloj([FromBody] ParadasRelojVM paradasReloj)
        {
            _paradasRelojService.AddParadaReloj(paradasReloj);
            return Ok();
        }

        [HttpGet("parada-de-reloj")]
        public IActionResult GetAllParadasRelojFromView(int page, int perPage)
        {
            if (page <= 0 || perPage <= 0)
            {
                var respuestaWebApiBadRequest = new { statusCode = 400, error = "Bad Request", message = "Los parámetros 'page' y 'perPage' deben ser números enteros positivos." };

                return Ok(respuestaWebApiBadRequest);
            }

            try
            {
                List<Data.ViewModels.ParadasRelojVM> allParadasReloj = _paradasRelojService.GetAllParadasRelojFromView(page, perPage);

                if (!allParadasReloj.Any())
                {
                    var respuestaWebApiNoExist = new { statusCode = 404, error = "Not Found", message = "No existen registros que cumplan los parametros dados" };

                    return NotFound(respuestaWebApiNoExist);
                }

                var respuestaWebApiOk = new { statusCode = 200, data = allParadasReloj };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
