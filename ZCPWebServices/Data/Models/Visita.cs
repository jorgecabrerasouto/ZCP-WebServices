using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data.Models
{
    public class Visita
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int idSede { get; set; } // Llave foranea
        public string tipoVisita { get; set; }
        public string fechaVisita { get; set; }
        public string resultadoVisita { get; set; }
        public string entidadResponsable { get; set; }
        public string descripcionHechosVerificacion { get; set; }
        public string interventorAsignado { get; set; }

        //propiedades de Navegación
        [JsonIgnore]
        public BaseZcp BaseZcp { get; set; }
    }
}
