using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ZCPWebServices.Data.Services;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Controllers
{
    [Route("consulta/")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
    public class TicketsController : ControllerBase
    {
        public TicketsService _ticketsService;

        public TicketsController(TicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet("get-all-tickets")]
        public IActionResult GetAllTickets()
        {
            try
            {
                List<Data.ViewModels.TicketsVM> allTickets = _ticketsService.GetAllTicketsWithoutId();
                var respuestaWebApiOk = new { statusCode = 200, data = allTickets };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tkt")]
        public IActionResult GetAllTicketsFromView(int page, int perPage)
        {
            if (page <= 0 || perPage <= 0)
            {
                var respuestaWebApiBadRequest = new { statusCode = 400, error = "Bad Request", message = "Los parámetros 'page' y 'perPage' deben ser números enteros positivos." };

                return Ok(respuestaWebApiBadRequest);
            }

            try
            {
                List<Data.ViewModels.TicketsVM> allTickets = _ticketsService.GetAllTicketsFromView(page, perPage);

                if (!allTickets.Any())
                {
                    var respuestaWebApiNoExist = new { statusCode = 404, error = "Not Found", message = "No existen registros que cumplan los parametros dados" };

                    return NotFound(respuestaWebApiNoExist);
                }

                var respuestaWebApiOk = new { statusCode = 200, data = allTickets };

                return Ok(respuestaWebApiOk);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /* 
               [HttpGet("get-all-tickets-async")]
               public async Task<IActionResult> GetAllTicketsAsync()
               {
                   try
                   {
                       List<TicketVM> allTickets = await _ticketsService.GetAllTicketsWithoutId();
                       var respuestaWebApi = new RespuestaWebApiOk();

                       respuestaWebApi.statusCode = 200;
                       respuestaWebApi.data = allTickets;

                       return Ok(respuestaWebApi);
                   }
                   catch (Exception ex)
                   {

                       return BadRequest(ex.Message);
                   }
               }
       */

        [HttpGet("get-ticket-by-id/{id}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketsService.GetTicketById(id);
            return Ok(ticket);
        }

        [HttpPost("add-ticket")]
        public IActionResult AddTicket([FromBody] Data.ViewModels.TicketsVM ticket)
        {
            _ticketsService.AddTicket(ticket);
            return Ok();
        }

        [HttpPut("update-ticket-by-id/{id}")]
        public IActionResult UdateTicketById(int id, [FromBody] Data.ViewModels.TicketsVM ticket)
        {
            var updatedTicket = _ticketsService.UpdateTicketById(id, ticket);
            return Ok(updatedTicket);
        }

        [HttpDelete("delete-ticket-by-id/{id}")]
        public IActionResult DeleteTicketById(int id)
        {
            _ticketsService.DeleteTicketById(id);
            return Ok();
        }

        private class TicketsVM
        {
        }
    }
}
