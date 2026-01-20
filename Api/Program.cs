using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ApplyConfig();

var app = builder.Build();

app.ApplyConfig();

app.Run();
