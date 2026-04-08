using System;
using System.Collections.Generic;
using System.Linq;
using ZCPWebServices.Data.Model;
using ZCPWebServices.Data.Paging;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class TicketsService
    {
        private AppDbContext _context;

        public TicketsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTicket(TicketsVM ticket)
        {
            var _ticket = new Ticket()
            {
                departamento = ticket.departamento,
                ejecutor = ticket.ejecutor,
                estado = ticket.estado,
                fechaCierre = ticket.fechaCierre,
                fechaInicio = ticket.fechaInicio,
                idZcp = ticket.idZcp,
                municipio = ticket.municipio,
                numeroTicketCcc = ticket.numeroTicketCcc,
                numeroTicketProveedor = ticket.numeroTicketProveedor,
                paradaReloj = ticket.paradaReloj,
                region = ticket.region,
                resumenCierre = ticket.resumenCierre,
                subcategoria = ticket.subcategoria

            };
            _context.Tickets.Add(_ticket);
            _context.SaveChanges();
        }

        public List<Ticket> GetAllTickets() => _context.Tickets.ToList();

        public List<TicketsVM> GetAllTicketsWithoutId()
        {
            IQueryable<TicketsVM> _ticketsWithoutId = _context.Tickets.Select(ticket => new TicketsVM()
            {
                departamento = ticket.departamento,
                ejecutor = ticket.ejecutor,
                estado = ticket.estado,
                fechaCierre = ticket.fechaCierre,
                fechaInicio = ticket.fechaInicio,
                idZcp = ticket.idZcp,
                municipio = ticket.municipio,
                numeroTicketCcc = ticket.numeroTicketCcc,
                numeroTicketProveedor = ticket.numeroTicketProveedor,
                paradaReloj = ticket.paradaReloj,
                region = ticket.region,
                resumenCierre = ticket.resumenCierre,
                subcategoria = ticket.subcategoria
            });

            return _ticketsWithoutId.ToList();
        }

        public List<TicketsVM> GetAllTicketsFromView(int page, int perPage)
        {
            var _ticketsFromView = _context.TicketsView.Select(ticket => new TicketsVM()
            {
                departamento = ticket.departamento,
                ejecutor = ticket.ejecutor,
                estado = ticket.estado,
                fechaCierre = ticket.fechaCierre,
                fechaInicio = ticket.fechaInicio,
                idZcp = ticket.idZcp,
                municipio = ticket.municipio,
                numeroTicketCcc = ticket.numeroTicketCcc,
                numeroTicketProveedor = ticket.numeroTicketProveedor,
                paradaReloj = ticket.paradaReloj,
                region = ticket.region,
                resumenCierre = ticket.resumenCierre,
                subcategoria = ticket.subcategoria
            }).ToList();

            //Pagination
            
            _ticketsFromView = PaginatedList<TicketsVM>.Create(_ticketsFromView.AsQueryable(), page, perPage);

            return _ticketsFromView;
        }

        public Ticket GetTicketById(int ticketId) => _context.Tickets.FirstOrDefault(t => t.Id == ticketId);

        public Ticket UpdateTicketById(int ticketId, TicketsVM ticket)
        {
            var _ticket = _context.Tickets.FirstOrDefault(t => t.Id == ticketId);
            if (_ticket != null)
            {
                _ticket.departamento = ticket.departamento;
                _ticket.ejecutor = ticket.ejecutor;
                _ticket.estado = ticket.estado;
                _ticket.fechaCierre = ticket.fechaCierre;
                _ticket.fechaInicio = ticket.fechaInicio;
                _ticket.idZcp = ticket.idZcp;
                _ticket.municipio = ticket.municipio;
                _ticket.numeroTicketCcc = ticket.numeroTicketCcc;
                _ticket.numeroTicketProveedor = ticket.numeroTicketProveedor;
                _ticket.paradaReloj = ticket.paradaReloj;
                _ticket.region = ticket.region;
                _ticket.resumenCierre = ticket.resumenCierre;
                _ticket.subcategoria = ticket.subcategoria;

                _context.SaveChanges();
            }

            return _ticket;
        }

        public void DeleteTicketById(int id)
        {
            var _ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (_ticket != null)
            {
                _context.Tickets.Remove(_ticket);
                _context.SaveChanges();
            }
        }
    }
}
