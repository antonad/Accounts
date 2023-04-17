using Api.Controllers;
using System.Net;

namespace Accounts.Api.Middleware
{
    public class ExceptionLoggingMiddleware
    {
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.Log(LogLevel.Error, ex, $"Error happened when processing request {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString.Value}");
            }
        }
    }

    public static class ExceptionLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionLogging(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggingMiddleware>();
        }
    }
}
