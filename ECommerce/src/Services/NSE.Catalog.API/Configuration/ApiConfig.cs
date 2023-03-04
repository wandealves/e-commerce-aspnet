using Microsoft.EntityFrameworkCore;

using NSE.Catalog.API.Data;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Catalog.API.Configuration
{
    public static class ApiConfig
    {
        private const string policyName = "Total";
        public static void AddApiConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<CatalogoContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                                  policy =>
                                  {
                                      policy
                                      .AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
        }

        public static ConfigurationManager AddApiConfiguration(this ConfigurationManager config, IWebHostEnvironment environment)
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

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseCors(policyName);
            app.UseAuthConfiguration();
            app.MapControllers();
        }
    }
}
