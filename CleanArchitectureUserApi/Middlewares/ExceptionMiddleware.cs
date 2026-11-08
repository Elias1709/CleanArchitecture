using FluentValidation;
using System.Text.Json;

namespace CleanArchitectureUserApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
       private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            switch (exception)
            {
                case ValidationException validationException:

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    var errors = validationException.Errors
                        .Select(x => x.ErrorMessage)
                        .ToList();

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(new
                        {
                            Errors = errors
                        }));
                    break;

                default:

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(new
                        {
                            Error = "Ha ocurrido un error interno."
                        }));
                    break;
            }
        }
    }
}
