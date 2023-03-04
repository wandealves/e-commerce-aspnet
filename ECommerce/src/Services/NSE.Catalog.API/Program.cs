using NSE.Catalog.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterService();

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration();

app.Run();
