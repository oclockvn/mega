var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.mega_Api>("mega-api");

await builder.Build().RunAsync();
