using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;

namespace DesignPatternsASP
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Existe 3 tipos de inyección de depencia
            /**
             * Por singleton
             * Por Transient
             * Por Scope
             */
            builder.Services.AddTransient((factory) =>
            {
                return new LocalEarnFactory(0.20m);
            });

            builder.Services.AddDbContext<DesignPatternsContext>(c =>
            {
                c.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
