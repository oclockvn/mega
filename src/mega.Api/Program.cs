using mega.Api.Infrastructure;
using mega.Api.Middleware;

namespace mega.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddMegaApi();
        builder.Services.AddMegaInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        app.UseDefaultFiles();
        app.MapStaticAssets();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // map global exception handler in the first place of the pipeline
        app.UseGlobalExceptionHandler();

        if (builder.Configuration.GetValue<int?>("ASPNET_HTTPS_PORT") != null)
        {
            app.UseHttpsRedirection();
        }
        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        await app.RunAsync();
    }
}
