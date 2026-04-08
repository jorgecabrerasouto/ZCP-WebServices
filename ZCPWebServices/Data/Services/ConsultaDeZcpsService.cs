using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;
using ZCPWebServices.Data.Paging;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Services
{
    public class ConsultaDeZcpsService
    {
        private AppDbContext _context;

        public ConsultaDeZcpsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddConsultaDeZcp(ConsultaDeZcpsVM consultaDeZcp)
        {
            var _consultaDeZcp = new ConsultaDeZcp()
            {
                asignacionEc = consultaDeZcp.asignacionEc,
                asignacionInstalacion = consultaDeZcp.asignacionInstalacion,
                asignacionOperacion = consultaDeZcp.asignacionOperacion,
                banda = consultaDeZcp.banda,
                clasificacionHechosEstudioCampo = consultaDeZcp.clasificacionHechosEstudioCampo,
                clasificacionHechosInstalacion = consultaDeZcp.clasificacionHechosInstalacion,
                codDaneMunicipio = consultaDeZcp.codDaneMunicipio,
                codDaneSede = consultaDeZcp.codDaneSede,
                comunicadoAprobacionRemota = consultaDeZcp.comunicadoAprobacionRemota,
                conceptoEstudioCampoInterventoria = consultaDeZcp.conceptoEstudioCampoInterventoria,
                conceptoInstalacionInterventoria = consultaDeZcp.conceptoInstalacionInterventoria,
                correoElectronicoDueInicial = consultaDeZcp.correoElectronicoDueInicial,
                correoElectronicoDueFinal = consultaDeZcp.correoElectronicoDueFinal,
                daneDepartamento = consultaDeZcp.daneDepartamento,
                departamento = consultaDeZcp.departamento,
                dificultadAccesoDda = consultaDeZcp.dificultadAccesoDda,
                dificultadAccesoEcDda = consultaDeZcp.dificultadAccesoEcDda,
                direccionSede = consultaDeZcp.direccionSede,
                estadoRevisionRemota = consultaDeZcp.estadoRevisionRemota,
                estadoSedeDue = consultaDeZcp.estadoSedeDue,
                estadoVisita = consultaDeZcp.estadoVisita,
                estadoVisitaRemota = consultaDeZcp.estadoVisitaRemota,
                fechaAprobacionEstudioCampo = consultaDeZcp.fechaAprobacionEstudioCampo,
                fechaAprobacionInstalacion = consultaDeZcp.fechaAprobacionInstalacion,
                fechaAprobacionRemota = consultaDeZcp.fechaAprobacionRemota,
                fechaReporteInstalacion = consultaDeZcp.fechaReporteInstalacion,
                fechaInicioOperacion = consultaDeZcp.fechaInicioOperacion,
                fechaEntregaEstudioCampo = consultaDeZcp.fechaEntregaEstudioCampo,
                fechaEntregaInstalacion = consultaDeZcp.fechaEntregaInstalacion,
                fechaEstudioCampo = consultaDeZcp.fechaEstudioCampo,
                fechaInstalacion = consultaDeZcp.fechaInstalacion,
                fechaRevisionRemota = consultaDeZcp.fechaRevisionRemota,
                fechaVisitaConfirmacion = consultaDeZcp.fechaVisitaConfirmacion,
                fechaVisitaInspeccion = consultaDeZcp.fechaVisitaInspeccion,
                fechaVisitaRemota = consultaDeZcp.fechaVisitaRemota,
                idBeneficiario = consultaDeZcp.idBeneficiario,
                idEjecutor = consultaDeZcp.idEjecutor,
                idZcpPropuestaCambioEstudiosDeCampo = consultaDeZcp.idZcpPropuestaCambioEstudiosDeCampo,
                idZcpPropuestaCambioInstalaciones = consultaDeZcp.idZcpPropuestaCambioInstalaciones,
                idZcpPropuestaTraslado = consultaDeZcp.idZcpPropuestaTraslado,
                iniciativa = consultaDeZcp.iniciativa,
                interventorRevisionRemota = consultaDeZcp.interventorRevisionRemota,
                latitudInicial = consultaDeZcp.latitudInicial,
                longitudInicial = consultaDeZcp.longitudInicial,
                matriculaTotal = consultaDeZcp.matriculaTotal,
                metaEstudioCampo = consultaDeZcp.metaEstudioCampo,
                metaInstalacion = consultaDeZcp.metaInstalacion,
                municipio = consultaDeZcp.municipio,
                nombreEe = consultaDeZcp.nombreEe,
                nombreSede = consultaDeZcp.nombreSede,
                prioridadProyectoZcp = consultaDeZcp.prioridadProyectoZcp,
                radicadoAprobacionInstalacion = consultaDeZcp.radicadoAprobacionInstalacion,
                radicadoAprobacionInterventoriaEc = consultaDeZcp.radicadoAprobacionInterventoriaEc,
                radicadoAprobacionInterventoriaReporteInstalacion = consultaDeZcp.radicadoAprobacionInterventoriaReporteInstalacion,
                radicadoEntregaEstudioCampo = consultaDeZcp.radicadoEntregaEstudioCampo,
                radicadoEntregaInstalacion = consultaDeZcp.radicadoEntregaInstalacion,
                rectorDueInicial = consultaDeZcp.rectorDueInicial,
                rectorDuefinal = consultaDeZcp.rectorDuefinal,
                regionProyectoZcp = consultaDeZcp.regionProyectoZcp,
                secretaria = consultaDeZcp.secretaria,
                idSede = consultaDeZcp.idSede,
                subRegionArt = consultaDeZcp.subRegionArt,
                Telefono = consultaDeZcp.Telefono,
                telefonoContacto = consultaDeZcp.telefonoContacto,
                tipoConectividad = consultaDeZcp.tipoConectividad,
                tipoEnergia = consultaDeZcp.tipoEnergia,
                tipoEnergiaEncontrado = consultaDeZcp.tipoEnergiaEncontrado,
                tipoRespaldoInstalado = consultaDeZcp.tipoRespaldoInstalado,
                velBajadaMbps = consultaDeZcp.velBajadaMbps,
                velSubidaMbps = consultaDeZcp.velSubidaMbps
            };

            _context.ConsultaDeZcps.Add(_consultaDeZcp);
            _context.SaveChanges();
        }

        public List<ConsultaDeZcpsVM> GetAllConsultaDeZcpsFromView(int page, int perPage)
        {
            var _consultaDeZcpFromView = _context.ConsultaDeZcpsView.Select(consultaDeZcp => new ConsultaDeZcpsVM()
            {
                asignacionEc = consultaDeZcp.asignacionEc,
                asignacionInstalacion = consultaDeZcp.asignacionInstalacion,
                asignacionOperacion = consultaDeZcp.asignacionOperacion,
                banda = consultaDeZcp.banda,
                clasificacionHechosEstudioCampo = consultaDeZcp.clasificacionHechosEstudioCampo,
                clasificacionHechosInstalacion = consultaDeZcp.clasificacionHechosInstalacion,
                codDaneMunicipio = consultaDeZcp.codDaneMunicipio,
                codDaneSede = consultaDeZcp.codDaneSede,
                comunicadoAprobacionRemota = consultaDeZcp.comunicadoAprobacionRemota,
                conceptoEstudioCampoInterventoria = consultaDeZcp.conceptoEstudioCampoInterventoria,
                conceptoInstalacionInterventoria = consultaDeZcp.conceptoInstalacionInterventoria,
                correoElectronicoDueInicial = consultaDeZcp.correoElectronicoDueInicial,
                correoElectronicoDueFinal = consultaDeZcp.correoElectronicoDueFinal,
                daneDepartamento = consultaDeZcp.daneDepartamento,
                departamento = consultaDeZcp.departamento,
                dificultadAccesoDda = consultaDeZcp.dificultadAccesoDda,
                dificultadAccesoEcDda = consultaDeZcp.dificultadAccesoEcDda,
                direccionSede = consultaDeZcp.direccionSede,
                estadoRevisionRemota = consultaDeZcp.estadoRevisionRemota,
                estadoSedeDue = consultaDeZcp.estadoSedeDue,
                estadoVisita = consultaDeZcp.estadoVisita,
                estadoVisitaRemota = consultaDeZcp.estadoVisitaRemota,
                fechaAprobacionEstudioCampo = consultaDeZcp.fechaAprobacionEstudioCampo,
                fechaAprobacionInstalacion = consultaDeZcp.fechaAprobacionInstalacion,
                fechaAprobacionRemota = consultaDeZcp.fechaAprobacionRemota,
                fechaReporteInstalacion = consultaDeZcp.fechaReporteInstalacion,
                fechaInicioOperacion = consultaDeZcp.fechaInicioOperacion,
                fechaEntregaEstudioCampo = consultaDeZcp.fechaEntregaEstudioCampo,
                fechaEntregaInstalacion = consultaDeZcp.fechaEntregaInstalacion,
                fechaEstudioCampo = consultaDeZcp.fechaEstudioCampo,
                fechaInstalacion = consultaDeZcp.fechaInstalacion,
                fechaRevisionRemota = consultaDeZcp.fechaRevisionRemota,
                fechaVisitaConfirmacion = consultaDeZcp.fechaVisitaConfirmacion,
                fechaVisitaInspeccion = consultaDeZcp.fechaVisitaInspeccion,
                fechaVisitaRemota = consultaDeZcp.fechaVisitaRemota,
                idBeneficiario = consultaDeZcp.idBeneficiario,
                idEjecutor = consultaDeZcp.idEjecutor,
                idZcpPropuestaCambioEstudiosDeCampo = consultaDeZcp.idZcpPropuestaCambioEstudiosDeCampo,
                idZcpPropuestaCambioInstalaciones = consultaDeZcp.idZcpPropuestaCambioInstalaciones,
                idZcpPropuestaTraslado = consultaDeZcp.idZcpPropuestaTraslado,
                iniciativa = consultaDeZcp.iniciativa,
                interventorRevisionRemota = consultaDeZcp.interventorRevisionRemota,
                latitudInicial = consultaDeZcp.latitudInicial,
                longitudInicial = consultaDeZcp.longitudInicial,
                matriculaTotal = consultaDeZcp.matriculaTotal,
                metaEstudioCampo = consultaDeZcp.metaEstudioCampo,
                metaInstalacion = consultaDeZcp.metaInstalacion,
                municipio = consultaDeZcp.municipio,
                nombreEe = consultaDeZcp.nombreEe,
                nombreSede = consultaDeZcp.nombreSede,
                prioridadProyectoZcp = consultaDeZcp.prioridadProyectoZcp,
                radicadoAprobacionInstalacion = consultaDeZcp.radicadoAprobacionInstalacion,
                radicadoAprobacionInterventoriaEc = consultaDeZcp.radicadoAprobacionInterventoriaEc,
                radicadoAprobacionInterventoriaReporteInstalacion = consultaDeZcp.radicadoAprobacionInterventoriaReporteInstalacion,
                radicadoEntregaEstudioCampo = consultaDeZcp.radicadoEntregaEstudioCampo,
                radicadoEntregaInstalacion = consultaDeZcp.radicadoEntregaInstalacion,
                rectorDueInicial = consultaDeZcp.rectorDueInicial,
                rectorDuefinal = consultaDeZcp.rectorDuefinal,
                regionProyectoZcp = consultaDeZcp.regionProyectoZcp,
                secretaria = consultaDeZcp.secretaria,
                idSede = consultaDeZcp.idSede,
                subRegionArt = consultaDeZcp.subRegionArt,
                Telefono = consultaDeZcp.Telefono,
                telefonoContacto = consultaDeZcp.telefonoContacto,
                tipoConectividad = consultaDeZcp.tipoConectividad,
                tipoEnergia = consultaDeZcp.tipoEnergia,
                tipoEnergiaEncontrado = consultaDeZcp.tipoEnergiaEncontrado,
                tipoRespaldoInstalado = consultaDeZcp.tipoRespaldoInstalado,
                velBajadaMbps = consultaDeZcp.velBajadaMbps,
                velSubidaMbps = consultaDeZcp.velSubidaMbps
            }).ToList();

            //Pagination

            _consultaDeZcpFromView = PaginatedList<ConsultaDeZcpsVM>.Create(_consultaDeZcpFromView.AsQueryable(), page, perPage);
            return _consultaDeZcpFromView;
        }
    }
}
