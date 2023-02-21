using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddWebAppConfiguration(builder.Environment);
builder.Services.AddIdentityConfiguration();
builder.Services.AddWebAppConfiguration(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();

app.UseWebAppConfiguration();

app.Run();
