using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Paging;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class ParadasRelojService
    {
        private AppDbContext _context;

        public ParadasRelojService(AppDbContext context)
        {
            _context = context;
        }

        public void AddParadaReloj(ParadasRelojVM paradasReloj)
        {
            var _paradasReloj = new ParadaReloj()
            {
                categoria = paradasReloj.categoria,
                departamento = paradasReloj.departamento,
                fechaFinFalla = paradasReloj.fechaFinFalla,
                fechaInicioFalla = paradasReloj.fechaInicioFalla,
                fechaInicioParada = paradasReloj.fechaInicioParada,
                motivoParadaReloj = paradasReloj.motivoParadaReloj,
                municipio = paradasReloj.municipio,
                numeroTicketCcc = paradasReloj.numeroTicketCcc,
                numeroTicketProveedor = paradasReloj.numeroTicketProveedor,
                region = paradasReloj.region,
                sedeId = paradasReloj.sedeId,
                subcategoria = paradasReloj.subcategoria,
                tiempoParadaReloj = paradasReloj.tiempoParadaReloj
            };
            _context.ParadaReloj.Add(_paradasReloj);
            _context.SaveChanges();
        }

        public List<ParadasRelojVM> GetAllParadasRelojFromView(int page, int perPage)
        {
            var _paradasRelojFromView = _context.ParadasRelojView.Select(paradasReloj => new ParadasRelojVM()
            {
                categoria = paradasReloj.categoria,
                departamento = paradasReloj.departamento,
                fechaFinFalla = paradasReloj.fechaFinFalla,
                fechaInicioFalla = paradasReloj.fechaInicioFalla,
                fechaInicioParada = paradasReloj.fechaInicioParada,
                motivoParadaReloj = paradasReloj.motivoParadaReloj,
                municipio = paradasReloj.municipio,
                numeroTicketCcc = paradasReloj.numeroTicketCcc,
                numeroTicketProveedor = paradasReloj.numeroTicketProveedor,
                region = paradasReloj.region,
                sedeId = paradasReloj.sedeId,
                subcategoria = paradasReloj.subcategoria,
                tiempoParadaReloj = paradasReloj.tiempoParadaReloj
            }).ToList();

            //Pagination

            _paradasRelojFromView = PaginatedList<ParadasRelojVM>.Create(_paradasRelojFromView.AsQueryable(), page, perPage);
            return _paradasRelojFromView;
        }
    }
}
