using Microsoft.AspNetCore.Identity;

namespace ZCPWebServices.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Custom { get; set; }
    }
}
