using System;

namespace ZCPWebServices.Data.ViewModels
{
    public class TicketsVM
    {
        public string departamento { get; set; }
        public string ejecutor { get; set; }
        public string estado { get; set; }
        public string? fechaCierre { get; set; }
        public string fechaInicio { get; set; }
        public string idZcp { get; set; }
        public string municipio { get; set; }
        public string numeroTicketCcc { get; set; }
        public string? numeroTicketProveedor { get; set; }
        public string paradaReloj { get; set; }
        public string region { get; set; }
        public string? resumenCierre { get; set; }
        public string subcategoria { get; set; }
    }
}
