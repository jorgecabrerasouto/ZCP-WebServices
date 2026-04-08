using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("/consulta")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class CaracterizacionesController : ControllerBase
    {
        private CaracterizacionesService _caracterizacionesService;

        public CaracterizacionesController(CaracterizacionesService caracterizacionesService)
        {
            _caracterizacionesService = caracterizacionesService;
        }

        [HttpPost("add-caracterizacion")]
        public IActionResult AddCaracterizacion([FromBody] CaracterizacionesVM caracterizacion)
        {
            _caracterizacionesService.AddCaracterizacion(caracterizacion);
            return Ok();
        }

        [HttpGet("caracterizacion")]
        public IActionResult GetAllCaracterizacionesFromView(int page, int perPage)
        {
            if (page <= 0 || perPage <= 0)
            {
                var respuestaWebApiBadRequest = new { statusCode = 400, error = "Bad Request", message = "Los parámetros 'page' y 'perPage' deben ser números enteros positivos." };

                return Ok(respuestaWebApiBadRequest);
            }

            try
            {
                List<Data.ViewModels.CaracterizacionesVM> allCaracterizaciones = _caracterizacionesService.GetAllCaracterizacionesFromView(page, perPage);

                if (!allCaracterizaciones.Any())
                {
                    var respuestaWebApiNoExist = new { statusCode = 404, error = "Not Found", message = "No existen registros que cumplan los parametros dados" };

                    return NotFound(respuestaWebApiNoExist);
                }

                var respuestaWebApiOk = new { statusCode = 200, data = allCaracterizaciones };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
