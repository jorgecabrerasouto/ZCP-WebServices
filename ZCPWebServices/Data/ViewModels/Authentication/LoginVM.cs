using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZCPWebServices.Data.ViewModels.Authentication
{
    public class LoginVM
    {
        [Required(ErrorMessage="El email del usuario es un dato requerido ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password del usuario es un dato requerido ")]
        public string Password { get; set; }
    }
}
