using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_NET5_IOCSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_NET5_IOCSample
{
    public class Startup
    {
        //IConfiguration stellt die gesamte Konfiguration 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Die IServiceCollection kann Dienst unter drei Lebenszyklen einbinden
            //services.AddSingleton
            //services.AddScope
            //services.AddTransient




            //Lieber IOC Container, wir verwenden MVC + Default Dienste, die wichtig sind
            services.AddControllersWithViews(); //MVC
            //services.AddControllers(); //WebAPI 
            //services.AddRazorPages(); //Geschwister UI -> Razor Page
            //services.AddMvc(); //RazorPage + MVC 

            services.AddTimeService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Wird nur für Development verwendet 
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Wird in der Produkiven Umgebung verwendet
                app.UseExceptionHandler("/Home/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); //
            }

            //Soll Allgemein verwendet werden
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
