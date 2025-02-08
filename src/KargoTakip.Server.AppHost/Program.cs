using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<KargoTakip_Server_WebAPI>("kargo-takip-webapi");

builder.Build().Run();
