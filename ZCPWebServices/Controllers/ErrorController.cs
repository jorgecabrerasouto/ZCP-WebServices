using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZCPWebServices.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            if (code == 401)
            {
                var respuestaWebApiNotFound = new { statusCode = code, error = "Unauthorized", message = "El cliente no pudo ser autenticado." };
                return Ok(respuestaWebApiNotFound);
            } else if(code == 404)
            {
                var respuestaWebApiNotFound = new { statusCode = code, error = "Not Found", message = "Ruta no encontrada." };
                return Ok(respuestaWebApiNotFound);
            } else
            {
                var respuestaWebApiNotFound = new { statusCode = code, error = "Method Bot Allowed", message = "La ruta seleccionada no tiene soporte para el ´método solicitado" };
                return Ok(respuestaWebApiNotFound);
            }
        }
    }
}
