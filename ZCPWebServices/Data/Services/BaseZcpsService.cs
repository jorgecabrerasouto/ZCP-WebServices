using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Paging;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class BaseZcpsService
    {
        private AppDbContext _context;

        public BaseZcpsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBaseZcp(ViewModels.BaseZcpsVM baseZcp)
        {
            var _baseZcp = new Models.BaseZcp()
            {
                asignacionEc = baseZcp.asignacionEc,
                asignacionInstalacion = baseZcp.asignacionInstalacion,
                asignacionOperacion = baseZcp.asignacionOperacion,
                banda = baseZcp.banda,
                clasificacionHechosEstudioCampo = baseZcp.clasificacionHechosEstudioCampo,
                clasificacionHechosInstalacion = baseZcp.clasificacionHechosInstalacion,
                codDaneMunicipio = baseZcp.codDaneMunicipio,
                codigoDaneEe = baseZcp.codigoDaneEe,
                codigoDaneSede = baseZcp.codigoDaneSede,
                comunicadoAprobacionRemota = baseZcp.comunicadoAprobacionRemota,
                conceptoEstudioCampoInterventoria = baseZcp.conceptoEstudioCampoInterventoria,
                conceptoInstalacionInterventoria = baseZcp.conceptoInstalacionInterventoria,
                correoElectronicoDueInicial = baseZcp.correoElectronicoDueInicial,
                correoElectronicoDueFinal = baseZcp.correoElectronicoDueFinal,
                daneDepartamento = baseZcp.daneDepartamento,
                departamento = baseZcp.departamento,
                dificultadAccesoDda = baseZcp.dificultadAccesoDda,
                dificultadAccesoEcDda = baseZcp.dificultadAccesoEcDda,
                direccionSede = baseZcp.direccionSede,
                estadoRevisionRemota = baseZcp.estadoRevisionRemota,
                estadoSedeDue = baseZcp.estadoSedeDue,
                estadoVisita = baseZcp.estadoVisita,
                estadoVisitaRemota = baseZcp.estadoVisitaRemota,
                fechaAprobacionEstudioCampo = baseZcp.fechaAprobacionEstudioCampo,
                fechaAprobacionInstalacion = baseZcp.fechaAprobacionInstalacion,
                fechaAprobacionRemota = baseZcp.fechaAprobacionRemota,
                fechaAprobacionReporteInstalacion = baseZcp.fechaAprobacionReporteInstalacion,
                fechaInicioOperacion = baseZcp.fechaInicioOperacion,
                fechaEntregaEstudioCampo = baseZcp.fechaEntregaEstudioCampo,
                fechaEntregaInstalacion = baseZcp.fechaEntregaInstalacion,
                fechaEstudioCampo = baseZcp.fechaEstudioCampo,
                fechaInstalacion = baseZcp.fechaInstalacion,
                fechaRevisionRemota = baseZcp.fechaRevisionRemota,
                fechaVisitaConfirmacion = baseZcp.fechaVisitaConfirmacion,
                fechaVisitaInspeccion = baseZcp.fechaVisitaInspeccion,
                fechaVisitaRemota = baseZcp.fechaVisitaRemota,
                idBeneficiario = baseZcp.idBeneficiario,
                idEjecutor = baseZcp.idEjecutor,
                idZcpPropuestaCambioEstudiosDeCampo = baseZcp.idZcpPropuestaCambioEstudiosDeCampo,
                idZcpPropuestaCambioInstalaciones = baseZcp.idZcpPropuestaCambioInstalaciones,
                idZcpPropuestaTraslado = baseZcp.idZcpPropuestaTraslado,
                iniciativa = baseZcp.iniciativa,
                latitudInicial = baseZcp.latitudInicial,
                longitudInicial = baseZcp.longitudInicial,
                latitudFinal = baseZcp.latitudFinal,
                longitudFinal = baseZcp.longitudFinal,
                matriculaTotal = baseZcp.matriculaTotal,
                metaEstudioCampo = baseZcp.metaEstudioCampo,
                metaInstalacion = baseZcp.metaInstalacion,
                municipio = baseZcp.municipio,
                nombreEe = baseZcp.nombreEe,
                nombreSede = baseZcp.nombreSede,
                prioridadProyectoZcp = baseZcp.prioridadProyectoZcp,
                radicadoAprobacionInstalacion = baseZcp.radicadoAprobacionInstalacion,
                radicadoAprobacionInterventoriaEc = baseZcp.radicadoAprobacionInterventoriaEc,
                radicadoAprobacionInterventoriaReporteInstalacion = baseZcp.radicadoAprobacionInterventoriaReporteInstalacion,
                radicadoEntregaEstudioCampo = baseZcp.radicadoEntregaEstudioCampo,
                radicadoEntregaInstalacion = baseZcp.radicadoEntregaInstalacion,
                rectorDueInicial = baseZcp.rectorDueInicial,
                rectorDuefinal = baseZcp.rectorDuefinal,
                regionProyectoZcp = baseZcp.regionProyectoZcp,
                secretaria = baseZcp.secretaria,
                idSede = baseZcp.idSede,
                subRegionArt = baseZcp.subRegionArt,
                Telefono = baseZcp.Telefono,
                telefonoContacto = baseZcp.telefonoContacto,
                tipoConectividad = baseZcp.tipoConectividad,
                tipoEnergia = baseZcp.tipoEnergia,
                tipoEnergiaEncontrado = baseZcp.tipoEnergiaEncontrado,
                tipoRespaldoInstalado = baseZcp.tipoRespaldoInstalado,
                velBajadaMbps = baseZcp.velBajadaMbps,
                velSubidaMbps = baseZcp.velSubidaMbps
            };

            _context.BaseZcp.Add(_baseZcp);
            _context.SaveChanges();
        }
        /*
        public List<ViewModels.BaseZcpsVM> GetAllBaseZcpsFromView(int page, int perPage)
        {
            var _baseZcpFromView = _context.BaseZcp.Select(baseZcp => new BaseZcpsVM()
            {
                asignacionEc = baseZcp.asignacionEc,
                asignacionInstalacion = baseZcp.asignacionInstalacion,
                asignacionOperacion = baseZcp.asignacionOperacion,
                banda = baseZcp.banda,
                clasificacionHechosEstudioCampo = baseZcp.clasificacionHechosEstudioCampo,
                clasificacionHechosInstalacion = baseZcp.clasificacionHechosInstalacion,
                codDaneMunicipio = baseZcp.codDaneMunicipio,
                codigoDaneEe = baseZcp.codigoDaneEe,
                codigoDaneSede = baseZcp.codigoDaneSede,
                comunicadoAprobacionRemota = baseZcp.comunicadoAprobacionRemota,
                conceptoEstudioCampoInterventoria = baseZcp.conceptoEstudioCampoInterventoria,
                conceptoInstalacionInterventoria = baseZcp.conceptoInstalacionInterventoria,
                correoElectronicoDueInicial = baseZcp.correoElectronicoDueInicial,
                correoElectronicoDueFinal = baseZcp.correoElectronicoDueFinal,
                daneDepartamento = baseZcp.daneDepartamento,
                departamento = baseZcp.departamento,
                dificultadAccesoDda = baseZcp.dificultadAccesoDda,
                dificultadAccesoEcDda = baseZcp.dificultadAccesoEcDda,
                direccionSede = baseZcp.direccionSede,
                estadoRevisionRemota = baseZcp.estadoRevisionRemota,
                estadoSedeDue = baseZcp.estadoSedeDue,
                estadoVisita = baseZcp.estadoVisita,
                estadoVisitaRemota = baseZcp.estadoVisitaRemota,
                fechaAprobacionEstudioCampo = baseZcp.fechaAprobacionEstudioCampo,
                fechaAprobacionInstalacion = baseZcp.fechaAprobacionInstalacion,
                fechaAprobacionRemota = baseZcp.fechaAprobacionRemota,
                fechaAprobacionReporteInstalacion = baseZcp.fechaAprobacionReporteInstalacion,
                fechaInicioOperacion = baseZcp.fechaInicioOperacion,
                fechaEntregaEstudioCampo = baseZcp.fechaEntregaEstudioCampo,
                fechaEntregaInstalacion = baseZcp.fechaEntregaInstalacion,
                fechaEstudioCampo = baseZcp.fechaEstudioCampo,
                fechaInstalacion = baseZcp.fechaInstalacion,
                fechaRevisionRemota = baseZcp.fechaRevisionRemota,
                fechaVisitaConfirmacion = baseZcp.fechaVisitaConfirmacion,
                fechaVisitaInspeccion = baseZcp.fechaVisitaInspeccion,
                fechaVisitaRemota = baseZcp.fechaVisitaRemota,
                idBeneficiario = baseZcp.idBeneficiario,
                idEjecutor = baseZcp.idEjecutor,
                idZcpPropuestaCambioEstudiosDeCampo = baseZcp.idZcpPropuestaCambioEstudiosDeCampo,
                idZcpPropuestaCambioInstalaciones = baseZcp.idZcpPropuestaCambioInstalaciones,
                idZcpPropuestaTraslado = baseZcp.idZcpPropuestaTraslado,
                iniciativa = baseZcp.iniciativa,
                latitudInicial = baseZcp.latitudInicial,
                longitudInicial = baseZcp.longitudInicial,
                latitudFinal = baseZcp.latitudFinal,
                longitudFinal = baseZcp.longitudFinal,
                matriculaTotal = baseZcp.matriculaTotal,
                metaEstudioCampo = baseZcp.metaEstudioCampo,
                metaInstalacion = baseZcp.metaInstalacion,
                municipio = baseZcp.municipio,
                nombreEe = baseZcp.nombreEe,
                nombreSede = baseZcp.nombreSede,
                prioridadProyectoZcp = baseZcp.prioridadProyectoZcp,
                radicadoAprobacionInstalacion = baseZcp.radicadoAprobacionInstalacion,
                radicadoAprobacionInterventoriaEc = baseZcp.radicadoAprobacionInterventoriaEc,
                radicadoAprobacionInterventoriaReporteInstalacion = baseZcp.radicadoAprobacionInterventoriaReporteInstalacion,
                radicadoEntregaEstudioCampo = baseZcp.radicadoEntregaEstudioCampo,
                radicadoEntregaInstalacion = baseZcp.radicadoEntregaInstalacion,
                rectorDueInicial = baseZcp.rectorDueInicial,
                rectorDuefinal = baseZcp.rectorDuefinal,
                regionProyectoZcp = baseZcp.regionProyectoZcp,
                secretaria = baseZcp.secretaria,
                idSede = baseZcp.idSede,
                subRegionArt = baseZcp.subRegionArt,
                Telefono = baseZcp.Telefono,
                telefonoContacto = baseZcp.telefonoContacto,
                tipoConectividad = baseZcp.tipoConectividad,
                tipoEnergia = baseZcp.tipoEnergia,
                tipoEnergiaEncontrado = baseZcp.tipoEnergiaEncontrado,
                tipoRespaldoInstalado = baseZcp.tipoRespaldoInstalado,
                velBajadaMbps = baseZcp.velBajadaMbps,
                velSubidaMbps = baseZcp.velSubidaMbps
            }).ToList();
        */
        public List<BaseZcp> GetAllBaseZcp(int page, int perPage)
        {
            var _baseZcpFromView = _context.BaseZcp.Include(x => x.Visitas).ToList();
         
        //Pagination

            _baseZcpFromView = PaginatedList<Models.BaseZcp>.Create(Queryable.AsQueryable<Models.BaseZcp>(_baseZcpFromView), page, perPage);
            return _baseZcpFromView;
        }
    }
}