namespace NSE.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static IServiceCollection AddWebAppConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            return services;
        }

        public static WebApplication UseWebAppConfiguration(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityConfiguration();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
