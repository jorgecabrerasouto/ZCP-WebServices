using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Models
{
    public class BaseZcp
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string asignacionEc { get; set; }
        public string asignacionInstalacion { get; set; }
        public string asignacionOperacion { get; set; }
        public string banda { get; set; }
        public string clasificacionHechosEstudioCampo { get; set; }
        public string clasificacionHechosInstalacion { get; set; }
        public string codDaneMunicipio { get; set; }
        public string codigoDaneEe { get; set; }
        public string codigoDaneSede { get; set; }
        public string comunicadoAprobacionRemota { get; set; }
        public string conceptoEstudioCampoInterventoria { get; set; }
        public string conceptoInstalacionInterventoria { get; set; }
        public string correoElectronicoDueInicial { get; set; }
        public string correoElectronicoDueFinal { get; set; }
        public string daneDepartamento { get; set; }
        public string departamento { get; set; }
        public string dificultadAccesoDda { get; set; }
        public string dificultadAccesoEcDda { get; set; }
        public string direccionSede { get; set; }
        public string estadoRevisionRemota { get; set; }
        public string estadoSedeDue { get; set; }
        public string estadoVisita { get; set; }
        public string estadoVisitaRemota { get; set; }
        public string fechaAprobacionEstudioCampo { get; set; }
        public string fechaAprobacionInstalacion { get; set; }
        public string fechaAprobacionRemota { get; set; }
        public string fechaAprobacionReporteInstalacion { get; set; }
        public string fechaInicioOperacion { get; set; }
        public string fechaEntregaEstudioCampo { get; set; }
        public string fechaEntregaInstalacion { get; set; }
        public string fechaEstudioCampo { get; set; }
        public string fechaInstalacion { get; set; }
        public string fechaRevisionRemota { get; set; }
        public string fechaVisitaConfirmacion { get; set; }
        public string fechaVisitaInspeccion { get; set; }
        public string fechaVisitaRemota { get; set; }
        public string idBeneficiario { get; set; }
        public string idEjecutor { get; set; }
        public string idZcpPropuestaCambioEstudiosDeCampo { get; set; }
        public string idZcpPropuestaCambioInstalaciones { get; set; }
        public string idZcpPropuestaTraslado { get; set; }
        public string iniciativa { get; set; }
        public string latitudInicial { get; set; }
        public string longitudInicial { get; set; }
        public string latitudFinal { get; set; }
        public string longitudFinal { get; set; }
        public string matriculaTotal { get; set; }
        public string metaEstudioCampo { get; set; }
        public string metaInstalacion { get; set; }
        public string municipio { get; set; }
        public string nombreEe { get; set; }
        public string nombreSede { get; set; }
        public string prioridadProyectoZcp { get; set; }
        public string radicadoAprobacionInstalacion { get; set; }
        public string radicadoAprobacionInterventoriaEc { get; set; }
        public string radicadoAprobacionInterventoriaReporteInstalacion { get; set; }
        public string radicadoEntregaEstudioCampo { get; set; }
        public string radicadoEntregaInstalacion { get; set; }
        public string rectorDueInicial { get; set; }
        public string rectorDuefinal { get; set; }
        public string regionProyectoZcp { get; set; }
        public string secretaria { get; set; }
        [Key]
        public int idSede { get; set; }
        public string subRegionArt { get; set; }
        public string Telefono { get; set; }
        public string telefonoContacto { get; set; }
        public string tipoConectividad { get; set; }
        public string tipoEnergia { get; set; }
        public string tipoEnergiaEncontrado { get; set; }
        public string tipoRespaldoInstalado { get; set; }
        public string velBajadaMbps { get; set; }
        public string velSubidaMbps { get; set; }

        // Propiedades de Navegacion
        public List<Visita> Visitas { get; set; }

    }
}
