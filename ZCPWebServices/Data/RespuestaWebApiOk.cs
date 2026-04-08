using System.Collections.Generic;
using ZCPWebServices.Data.ViewModels;

namespace ZCPWebServices.Data
{
    public class RespuestaWebApiOk
    {
        public int statusCode { get; set; }
        public List<TicketsVM> data { get; set; }
    }
}
