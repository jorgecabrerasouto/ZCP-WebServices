using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using ZCPWebServices.Data.ViewModels;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Data.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
           {
               appError.Run(async context =>
               {
                   
                   context.Response.ContentType = "application/json";
                   context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                   IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                   var contextRequest = context.Features.Get<IHttpRequestFeature>();

                   if (contextFeature != null)
                   {
                       await context.Response.WriteAsync(new ErrorVM()
                       {
                           statusCode = context.Response.StatusCode,
                           error = context.Response.StatusCode switch
                           {
                               200 => "OK",
                               400 => "Bad Request",
                               401 => "Unauthorized",
                               404 => "Not found",
                               500 => "Internal Server Error",
                               502 => "Bad Gateway",
                               _ => "Internal Server Error from the custom Middleware"
                           },
                           message = contextFeature.Error.Message
                       }.ToString());
                   }
               });
           });
        }

        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
