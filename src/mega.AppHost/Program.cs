var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.mega_Api>("mega-api").WithHttpEndpoint(name: "api-http").WithExternalHttpEndpoints();

//var _clientApp = builder.AddPnpmApp("mega-client", "../mega.ClientApp", "dev")
//    .WithReference(apiService)
//    .WithEnvironment("BROWSER", "none")
//    .WithHttpEndpoint(env: "VITE_PORT")
//    .WithExternalHttpEndpoints()
//    .PublishAsDockerFile();

var clientApp = builder.AddViteApp("mega-client", "../mega.ClientApp", "pnpm")
    .WithReference(apiService)
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(name: "client-http", env: "VITE_PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

await builder.Build().RunAsync();
