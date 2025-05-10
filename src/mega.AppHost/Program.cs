using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();

if (isDevelopment)
{
    builder.Configuration.AddUserSecrets<Program>();
}

var apiService = builder.AddProject<Projects.mega_Api>("api")
    // by default apiService exposes 2 endpoints: http and https
    // 2 environment variables below will be injected to clientApp (its dependent)
    // services__api__http__0, services__api__https__0
    //.WithHttpEndpoint(name: "endpoint") // will result as new env variable services__api__endpoint__0, however we don't need to configure it
    .WithExternalHttpEndpoints();

builder.AddPnpmApp("frontend", "../mega.ClientApp", "dev")
   .WithReference(apiService)
   .WithEnvironment("BROWSER", "none")
#if DEBUG
   .WithEnvironment("VITE_PORT", "4200")
   .WithHttpEndpoint(env: "VITE_PORT", targetPort: 4200) // we don't need this as we don't need to expose client endpoint
#else
   .WithHttpsEndpoint(env: "VITE_PORT") // we don't need this as we don't need to expose client endpoint
#endif
   .WithExternalHttpEndpoints()
   .WaitFor(apiService)
   .PublishAsDockerFile();

//builder.AddViteApp("frontend", "../mega.ClientApp", "pnpm")
//   .WithReference(apiService)
//   .WithEnvironment("BROWSER", "none")
//   .WithHttpEndpoint(env: "VITE_PORT") // we don't need this as we don't need to expose client endpoint
//   .WithExternalHttpEndpoints()
//   .WaitFor(apiService)
//   .PublishAsDockerFile();

await builder.Build().RunAsync();
