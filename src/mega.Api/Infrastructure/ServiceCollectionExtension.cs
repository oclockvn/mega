using mega.Api.Application.Exceptions;
using mega.Api.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace mega.Api.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMegaInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment = false)
    {
        return services
            .AddDb(configuration, isDevelopment)
            ;
    }

    private static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration, bool isDevelopment = false)
    {
        services.Configure<DbSetting>(configuration.GetSection(DbSetting.SECTION_NAME));
        services.AddDbContextFactory<ApplicationDbContext>((sp, options) =>
        {
            var connectionString = sp.GetRequiredService<IOptions<DbSetting>>().Value.ConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidAppSettingException("Connection string is not set");
            }

            options
                .UseSqlServer(connectionString)
                .EnableDetailedErrors(true);

            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging(true);
            }
        });

        return services;
    }
}
