using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InsurancePolicy.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Log the incoming request
            _logger.LogInformation($"Handling request: {httpContext.Request.Method} {httpContext.Request.Path}");

            // Continue processing the request
            await _next(httpContext);

            // Log the outgoing response
            stopwatch.Stop();
            _logger.LogInformation($"Finished handling request. Response: {httpContext.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
