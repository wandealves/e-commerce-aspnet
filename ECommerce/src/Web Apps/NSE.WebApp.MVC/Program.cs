using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();
builder.Services.AddWebAppConfiguration();

var app = builder.Build();

app.UseWebAppConfiguration();

app.Run();
