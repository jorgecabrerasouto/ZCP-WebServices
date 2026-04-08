using System.Text.Json;

namespace ZCPWebServices.Data.ViewModels.Authentication
{
    public class ErrorVM
    {
        public int statusCode { get; set; }
        public string error { get; set; }
        public string message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
