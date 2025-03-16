using mega.Api.Application;
using mega.Api.Application.Exceptions;
using mega.Api.Application.Resolvers;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace mega.Api.Middleware;

public static class GlobalExceptionHandlerExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        // This middleware should be registered first in the pipeline to catch all exceptions
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-9.0#exception-handler-lambda
        return app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = Text.Plain;

                var exceptionContext = context.Features.Get<IExceptionHandlerPathFeature>();

                var logger = exceptionHandlerApp.ApplicationServices.GetRequiredService<ILogger<IExceptionHandlerPathFeature>>();
                var exception = exceptionContext!.Error;

                logger.LogError(exception, "[GLOBAL] Error occurred by request {Request}, exception: {Exception}{InnerException}", GetCurrentRequestUrl(context), exception.Message, exception.InnerException?.Message);

                ResultCode resultCode = ResultCode.InternalServerError;
                if (exception is InvalidAppSettingException)
                {
                    resultCode = ResultCode.InternalServerError;
                }
                else if (exception is EntityNotFoundException)
                {
                    resultCode = ResultCode.EntityNotFound;
                }
                else if (exception is BusinessRuleViolationException)
                {
                    resultCode = ResultCode.BusinessRuleViolation;
                }

                var message = exception.Message + exception.InnerException?.Message;
#if DEBUG
                message += exception.StackTrace;
#endif

                var correlationId = context.RequestServices.GetRequiredService<ICorrelationIdResolver>().Resolve();

                ResultContext<int> result = new(message, correlationId, resultCode);
                await context.Response.WriteAsJsonAsync(result);
            });
        });
    }

    private static string GetCurrentRequestUrl(HttpContext httpContext)
    {
        var request = httpContext.Request;
        return $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
    }
}

