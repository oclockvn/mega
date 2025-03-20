using mega.Api.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace mega.Api;

public class ApplicationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddUserSecrets<ApplicationDesignTimeDbContextFactory>()
            .Build();

        var connectionString = GetConnectionString(args);
        if (string.IsNullOrWhiteSpace(connectionString))
            connectionString = configuration.GetValue<string>($"{DbSetting.SECTION_NAME}:{nameof(DbSetting.ConnectionString)}");

        if (!string.IsNullOrWhiteSpace(connectionString))
            Console.WriteLine($"> Migrating using connection string: {connectionString}");

        var dbOption = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new ApplicationDbContext(dbOption);
    }

    private static string GetConnectionString(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--connection" && i + 1 < args.Length)
            {
                return args[i + 1];
            }
        }

        return string.Empty;
    }
}
