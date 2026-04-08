using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Paging;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class CaracterizacionesService
    {
        private AppDbContext _context;

        public CaracterizacionesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCaracterizacion(CaracterizacionesVM caracterizacion)
        {
            var _caracterizacion = new Caracterizacion()
            {
                departamento = caracterizacion.departamento,
                edad = caracterizacion.edad,
                educacion = caracterizacion.educacion,
                etnia = caracterizacion.etnia,
                fecha = caracterizacion.fecha,
                genero = caracterizacion.genero,
                identificacion = caracterizacion.identificacion,
                mac = caracterizacion.mac,
                municipio = caracterizacion.municipio,
                region = caracterizacion.region,
                sedeId = caracterizacion.sedeId
            };
            _context.Caracterizaciones.Add(_caracterizacion);
            _context.SaveChanges();
        }

        public List<CaracterizacionesVM> GetAllCaracterizacionesFromView(int page, int perPage)
        {
            var _caracterizacionesFromView = _context.CaracterizacionesView.Select(caracterizacion => new CaracterizacionesVM()
            {
                departamento = caracterizacion.departamento,
                edad = caracterizacion.edad,
                educacion = caracterizacion.educacion,
                etnia = caracterizacion.etnia,
                fecha = caracterizacion.fecha,
                genero = caracterizacion.genero,
                identificacion = caracterizacion.identificacion,
                mac = caracterizacion.mac,
                municipio = caracterizacion.municipio,
                region = caracterizacion.region,
                sedeId = caracterizacion.sedeId
            }).ToList();

            //Pagination

            _caracterizacionesFromView = PaginatedList<CaracterizacionesVM>.Create(_caracterizacionesFromView.AsQueryable(), page, perPage);
            return _caracterizacionesFromView;
        }
    }
}
