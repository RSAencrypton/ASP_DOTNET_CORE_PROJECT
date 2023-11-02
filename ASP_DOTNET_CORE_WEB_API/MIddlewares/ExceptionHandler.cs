using System.Net;

namespace ASP_DOTNET_CORE_WEB_API.MIddlewares
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandler> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errId = Guid.NewGuid();
                logger.LogError(ex, $"{errId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errId,
                    ErrorMessage = "The server has some problem!!!"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
