using mega.Api.Application.Resolvers;

namespace mega.Api.HttpResolvers;

public class HttpContextCorrelationIdResolver(IHttpContextAccessor httpContextAccessor) : ICorrelationIdResolver
{
    public string Resolve()
    {
        var header = httpContextAccessor.HttpContext?.Request.Headers["X-Correlation-ID"];
        return header is null ? string.Empty : header.Value.ToString();
    }
}
