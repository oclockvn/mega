var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.mega_Api>("mega-api").WithExternalHttpEndpoints();

var clientApp = builder.AddPnpmApp("mega-client", "../mega.ClientApp", "dev")
    .WithReference(apiService)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "VITE_PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync();
