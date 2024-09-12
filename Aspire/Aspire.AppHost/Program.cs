var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.API>("api");

builder.AddProject<Projects.Blazor>("blazor");

builder.AddProject<Projects.DomainModels>("domainmodels");

builder.Build().Run();

