
using mega.Api.Infrastructure;
using mega.Api.Middleware;

namespace mega.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddMegaApi();
        builder.Services.AddMegaInfrastructure(builder.Configuration, builder.Environment.IsDevelopment());

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // map global exception handler in the first place of the pipeline
        app.UseGlobalExceptionHandler();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}
