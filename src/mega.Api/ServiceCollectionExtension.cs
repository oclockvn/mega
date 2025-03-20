using mega.Api.Application.Resolvers;
using mega.Api.HttpResolvers;

namespace mega.Api;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMegaApi(this IServiceCollection services)
    {
        return services
            .AddScoped<ICorrelationIdResolver, HttpContextCorrelationIdResolver>()
            ;
    }
}
