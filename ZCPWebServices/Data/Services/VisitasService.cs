using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class VisitasService
    {
        private AppDbContext _context;

        public VisitasService(AppDbContext context)
        {
            _context = context;
        }

        public void AddVisita(VisitasVM visita)
        {
            var _visita = new Visita()
            {
                idSede = visita.idSede, // Llave primaria
                tipoVisita = visita.tipoVisita,
                fechaVisita = visita.fechaVisita,
                resultadoVisita = visita.resultadoVisita,
                entidadResponsable = visita.entidadResponsable,
                descripcionHechosVerificacion = visita.descripcionHechosVerificacion,
                interventorAsignado = visita.interventorAsignado
            };

            _context.Visitas.Add(_visita);
            _context.SaveChanges();
        }

        public List<Visita> GetAllVisitas() => _context.Visitas.ToList();

        public List<VisitasVM> GetAllVisitasWithoutId()
        {
            IQueryable<VisitasVM> _visitasWithoutId = _context.Visitas.Select(visita => new VisitasVM()
            {
                idSede = visita.idSede, // Llave primaria
                tipoVisita = visita.tipoVisita,
                fechaVisita = visita.fechaVisita,
                resultadoVisita = visita.resultadoVisita,
                entidadResponsable = visita.entidadResponsable,
                descripcionHechosVerificacion = visita.descripcionHechosVerificacion,
                interventorAsignado = visita.interventorAsignado
            });

            return _visitasWithoutId.ToList();
        }
    }
}
