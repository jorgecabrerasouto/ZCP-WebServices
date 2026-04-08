using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZCPWebServices.Data.Models
{
    public class ParadaReloj
    {
        public int Id { get; set; }
        public string categoria { get; set; }
        public string departamento { get; set; }
        public string fechaFinFalla { get; set; }
        public string fechaInicioFalla { get; set; }
        public string fechaInicioParada { get; set; }
        public string motivoParadaReloj { get; set; }
        public string municipio { get; set; }
        public string numeroTicketCcc { get; set; }
        public string numeroTicketProveedor { get; set; }
        public string region { get; set; }
        public int sedeId { get; set; }
        public string subcategoria { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal tiempoParadaReloj { get; set; }
    }
}
