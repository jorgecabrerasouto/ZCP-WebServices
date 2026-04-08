using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ZCPWebServices.Data;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("consulta/")]
    [ApiController]
    [Authorize (Roles = UserRoles.Admin+","+UserRoles.User)]
    public class VisitasController : ControllerBase
    {
        public VisitasService _visitasService;

        public VisitasController(VisitasService visitasService)
        {
            _visitasService = visitasService;
        }


        [HttpPost("add-visitas")]
        public IActionResult AddVisita([FromBody] Data.ViewModels.VisitasVM visita)
        {
            _visitasService.AddVisita(visita);
            return Ok();
        }

    }
}
