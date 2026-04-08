using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZCPWebServices.Data.ViewModels.Authentication
{
    public class TokenRequestVM
    {
        public string Token { get; set; }
        public String RefreshToken { get; set; }
    }
}
