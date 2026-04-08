using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Models;

namespace ZCPWebServices.Data.ViewModels
{
    public class VisitasVM
    {
        public int idSede { get; set; } // Llave foranea
        public string tipoVisita { get; set; }
        public string fechaVisita { get; set; }
        public string resultadoVisita { get; set; }
        public string entidadResponsable { get; set; }
        public string descripcionHechosVerificacion { get; set; }
        public string interventorAsignado { get; set; }

    }
}

