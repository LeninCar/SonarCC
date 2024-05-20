using backend_todo.Exeptions;
using backend_todo.Models.Middleware;
using Newtonsoft.Json;
using System.Net;

namespace backend_todo.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var errorMessage = ex.Message;

                switch (ex)
                {
                    case CustomException customException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = customException.Message;
                        break;

                    // Aquí puedes manejar otras excepciones específicas si es necesario

                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var errorResponse = new ErrorResponse(statusCode, errorMessage);
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }
}
