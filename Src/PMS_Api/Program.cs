using Infrastructure.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyGroup_Infrastructure();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
