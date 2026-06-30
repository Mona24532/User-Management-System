using Backend.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backend
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware>logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception Ocurred");
                await HandleExceptionAsync(httpContext,e);
            }
            
        }
        private static Task HandleExceptionAsync(HttpContext context,Exception e)
        {
            context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "Valami történt!";
            switch (e)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = e.Message;
                    break;

                case BadRequestException:
                    status = HttpStatusCode.BadRequest;
                    message = e.Message;
                    break;

                case UnauthorizedException:
                    status = HttpStatusCode.Unauthorized;
                    message = e.Message;
                    break;
                default:
                    message = e.Message;
                    break;
            }
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsJsonAsync(new
            {
                message,
                detail = e.Message
            });

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
