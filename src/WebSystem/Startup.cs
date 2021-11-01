using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGP.Infrastructure.GatewayLocator;
using SGP.Patrimony.Infrastructure.PatrimonyLocator;
using SGP.Patrimony.Repository.PatrimonyRepository;
using System.Collections.Generic;
using System.Globalization;

namespace SGP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.ConfigurePatrimonyService();
            services.ConfigureGatewayService();
            services.AddHttpContextAccessor();
            services.AddDbContext<SGPContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SGPContext")));

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Setting the default culture: pt-BR
            var defaultDateCulture = "pt-BR";
            //Solução para identificar localização e resolver o problema do decimal
            // Formatter number
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //Solução para identificar localização e resolver o problema do decimal
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
        {
             ci,
        },
                SupportedUICultures = new List<CultureInfo>
        {
             ci,
        }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Equipamento}/{action=Index}/{id?}");
            });
        }
    }
}
