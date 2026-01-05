using GameStore.Utils.Exceptions;
using System.Net;

namespace GameStore.Web.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        logger.LogError(ex, "Exception of type {ExType} occurred", ex.GetType());

        if (context.Response.HasStarted)
        {
            logger.LogWarning("Response has already started, cannot modify status code");
            return;
        }

        var statusCode = GetStatusCodeByException(ex);
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            Error = new
            {
                Code = ex.GetType().Name,
                Message = ex.Message,
                StatusCode = statusCode,
                Timestamp = DateTime.UtcNow
            }
        };

        context.Response.Headers.ContentSecurityPolicy = "default-src 'self'";
        context.Response.Headers.XContentTypeOptions = "nosniff";
        context.Response.Headers.XFrameOptions = "DENY";

        await context.Response.WriteAsJsonAsync(response);
    }
    
    private static int GetStatusCodeByException(Exception ex)
    {
        return ex switch
        {
            EntryDuplicateException => (int)HttpStatusCode.BadRequest,
            BadRequestException => (int)HttpStatusCode.BadRequest,
            UnauthorizedException => (int)HttpStatusCode.Unauthorized,
            ForbiddenException => (int)HttpStatusCode.Forbidden,
            NotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}