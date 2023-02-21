using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static IServiceCollection AddWebAppConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);

            return services;
        }

        public static ConfigurationManager AddWebAppConfiguration(this ConfigurationManager config, IWebHostEnvironment environment)
        {
            config
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", false, true)
            .AddEnvironmentVariables();

            if (environment.IsDevelopment())
            {
                config.AddUserSecrets<Program>();
            }

            return config;
        }

        public static WebApplication UseWebAppConfiguration(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
