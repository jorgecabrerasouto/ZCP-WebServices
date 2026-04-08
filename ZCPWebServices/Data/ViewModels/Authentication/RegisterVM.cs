using System.ComponentModel.DataAnnotations;

namespace ZCPWebServices.Data.ViewModels.Authentication
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "El Nombre del usuario es un dato requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Email del usuario es un dato requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Password del usuario es un dato requerido")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "El Rol del usuario es un dato requerido")]
        public string Role { get; set; }
    }
}
