
using System.Net;
using System.Text.Json;

namespace ApexaTechAssess.Api.ExternalSystems
{
    public class CustomExceptionLogger : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionLogger(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex,_logger);
            }
           
        }

        // Method to handle exceptions
        private static Task HandleExceptionAsync(HttpContext context, Exception exception,ILogger logger)
        {
            // Set the response content type to JSON
            context.Response.ContentType = "application/json";
            // Set the status code to 500 (Internal Server Error)
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // Create a JSON response with the error message and details
            var result = JsonSerializer.Serialize(new { Message = "An unexpected error occurred.", Detail = exception.Message });
            logger.LogError(result);
            // Write the JSON response to the HTTP response
            return context.Response.WriteAsync(result);
        }

        
    }
}
