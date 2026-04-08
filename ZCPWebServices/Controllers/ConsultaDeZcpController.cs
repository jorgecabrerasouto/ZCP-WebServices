using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Controllers
{
    [Route("/consulta")]
    [ApiController]
    public class ConsultaDeZcpController : ControllerBase
    {
        private ConsultaDeZcpsService _consultaDeZcpsService;

        public ConsultaDeZcpController(ConsultaDeZcpsService consultaDeZcpsService)
        {
            _consultaDeZcpsService = consultaDeZcpsService;
        }

        [HttpPost("add-consulta-de-zcp")]
        public IActionResult AddConsultaDeZcp([FromBody] ConsultaDeZcpsVM consultaDeZcp)
        {
            _consultaDeZcpsService.AddConsultaDeZcp(consultaDeZcp);
            return Ok();
        }

        [HttpGet("zcp")]
        public IActionResult GetAllConsultaDeZcpsFromView(int page, int perPage)
        {
            if (page <= 0 || perPage <= 0)
            {
                var respuestaWebApiBadRequest = new { statusCode = 400, error = "Bad Request", message = "Los parámetros 'page' y 'perPage' deben ser números enteros positivos." };

                return Ok(respuestaWebApiBadRequest);
            }

            try
            {
                List<Data.ViewModels.ConsultaDeZcpsVM> allConsultaDeZcps = _consultaDeZcpsService.GetAllConsultaDeZcpsFromView(page, perPage);

                var respuestaWebApiOk = new { statusCode = 200, data = allConsultaDeZcps };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
