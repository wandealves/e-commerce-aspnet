namespace NSE.Autenticacao.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            return services;
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

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {

            app.UseHttpsRedirection();

            app.UseIdentityConfiguration();

            app.MapControllers();

            return app;
        }
    }
}
