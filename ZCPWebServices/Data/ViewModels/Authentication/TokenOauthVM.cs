namespace ZCPWebServices.Data.ViewModels.Authentication
{
    public class TokenOauthVM
    {
        //[Required(ErrorMessage = "El client_id es un dato requerido ")]
        public string client_id { get; set; }

        //[Required(ErrorMessage = "El client_secret es un dato requerido ")]
        public string client_secret { get; set; }

        //[Required(ErrorMessage = "El grant_type es un dato requerido ")]
        public string grant_type { get; set; }
    }
}
