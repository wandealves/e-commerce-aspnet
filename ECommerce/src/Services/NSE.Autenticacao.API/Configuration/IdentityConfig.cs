using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using NSE.Autenticacao.API.Data;
using NSE.Autenticacao.API.Extensions;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Autenticacao.API.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                   .AddRoles<IdentityRole>()
                   .AddErrorDescriber<IdentityMensagensPortugues>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);
        }
    }
}
