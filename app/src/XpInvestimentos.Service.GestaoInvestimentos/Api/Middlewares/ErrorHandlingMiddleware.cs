using Core.Interfaces;

namespace Api.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next, ILoggerGenerator logger)
    {
        private readonly RequestDelegate _next = next;

        private readonly ILoggerGenerator _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                object response = new
                {
                    Code = StatusCodes.Status500InternalServerError, 
                    Message = "erro inesperado.", 
                    Error = e.Message
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                context.Response.ContentType = "application/json";

                _logger.Error("erro inesperado", e);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}