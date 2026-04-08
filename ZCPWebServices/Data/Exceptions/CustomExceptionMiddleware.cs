using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using ZCPWebServices.Data.ViewModels;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Data.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorVM()
            {
                statusCode = httpContext.Response.StatusCode,
                error = "Internal Server Error",
                message = "Internal Server Error from the custom middleware",
            };

            return httpContext.Response.WriteAsync(response.ToString());
        }
    }
}
