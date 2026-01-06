using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace GameStore.Web.Filters
{
    public class LogActionFilter(ILogger<LogActionFilter> logger) : IAsyncActionFilter
    {
        private Stopwatch _stopwatch;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {   
            _stopwatch = Stopwatch.StartNew();
            await next();

            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            var actionName = context.ActionDescriptor.RouteValues["action"];

            var ipAddress = GetIpAddress(context);

            logger.LogInformation("[{0}] Action took: {1}ms; Client IP: {2}", actionName, elapsedMilliseconds, ipAddress);
        }

        private string GetIpAddress(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            return remoteIp ?? "Unknown";
        }
    }
}
