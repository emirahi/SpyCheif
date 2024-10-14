

using FluentValidation;
using Microsoft.AspNetCore.Http;
using SpyCheif.Application.Feature.Base;
using System.Text.Json;

namespace SpyCheif.Infrastructure.Middleware.Validation
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = 403;
                httpContext.Response.ContentType = "application/json";
                var response = new BaseResponse() { Status = false, Message = "Bir Sorun ile karşılaşıldı." };

                if (e is ValidationException validationException)
                {
                    var errors = validationException.Errors.Select(failure => failure.ErrorMessage).ToList();
                    response.Message = string.Join(", ", errors.Select(error => error.Replace("'","")));
                }
                httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));

            }

        }


    }
}
