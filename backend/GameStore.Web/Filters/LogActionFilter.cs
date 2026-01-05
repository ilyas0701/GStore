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
            var requestType = context.HttpContext.Request.Method;

            var message = $"[{requestType} {actionName}] Action took: {elapsedMilliseconds}ms";
            var ipAddress = GetIPAddress(context);

            if (!string.IsNullOrEmpty(ipAddress))
            {
                message += $" Client IP: {ipAddress}.";
            }

            logger.LogInformation(message);
        }

        private string GetIPAddress(ActionExecutingContext context)
        {
            var forwardedFor = context.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedFor))
            {
                return forwardedFor.Split(',').First().Trim();
            }

            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;

            if (remoteIp == null)
            {
                return "Unknown";
            }

            if (remoteIp.IsIPv4MappedToIPv6)
            {
                remoteIp = remoteIp.MapToIPv4();
            }

            return remoteIp.ToString();
        }
    }
}
