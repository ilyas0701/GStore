using System.Globalization;
using System.Net;
using GameStore.Utils.Exceptions;
using GameStore.Utils.Extensions;
using GameStore.Utils.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace GameStore.Web.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    private static readonly string HstsMaxAge = Convert.ToInt64(Math.Floor(TimeSpan.FromDays(30)
            .TotalSeconds))
        .ToString(CultureInfo.InvariantCulture);

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
            HandleStatusCodes(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        logger.LogError(ex, "Exception of type {ExType} occurred", ex.GetType());

        var statusCode = GetStatusCodeByException(ex);
        context.Response.StatusCode = statusCode;
        var response = InternalErrorCode.UnknownError;

        if (context.Request.IsHttps)
            context.Response.Headers.StrictTransportSecurity = new StringValues($"max-age={HstsMaxAge}{StringSegment.Empty}{StringSegment.Empty}");

        context.Response.Headers.ContentSecurityPolicy = "default-src 'self'";

        await context.Response.WriteAsync(response.SerializeToJson());
    }
    
    private static int GetStatusCodeByException(Exception ex)
    {
        return ex switch
        {
            EntryDuplicateException => 400,
            BadRequestException => 400,
            UnauthorizedException => 401,
            ForbiddenException => 403,
            NotFoundException => 404,
            _ => 500
        };
    }
    
    private static void HandleStatusCodes(HttpContext context)
    {
        switch (context.Response.StatusCode)
        {
            case (int)HttpStatusCode.NotFound: throw new NotFoundException($"There is nothing by the URL requested {context.Request.Path}");
            case (int)HttpStatusCode.Unauthorized: throw new UnauthorizedException();
            case (int)HttpStatusCode.Forbidden: throw new ForbiddenException();
            default: return;
        }
    }
}