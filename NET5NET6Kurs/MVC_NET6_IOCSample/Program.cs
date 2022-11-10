using Microsoft.EntityFrameworkCore;
using MVC_NET6_IOCSample.Data;
using MVC_NET6_IOCSample.Services;
using static System.Formats.Asn1.AsnWriter;

namespace MVC_NET6_IOCSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Neu in .NET ist die WebApplication + WebApplicationBuilder

            //Seperation of Concerne (Aufgabenteilung) 
            var builder = WebApplication.CreateBuilder(args);

            //IWebHostBuilder -> builder.WebHost (wurde in ASPNETCore 2.1 verwendet) 
            //IHostBuilder -> builder.Host (ab ASPNETCore 3.1) 

            #region Initialisierung der ServiceCollection: builder.Services
            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                //Möglichkeiten von Optionen mit Lambda
               // options.
            });
            //weitere Services hinzufügen 
            builder.Services.AddSingleton<ITimeService, TimeService>();
            builder.Services.AddSingleton<TimeService2>();


            //Einbinden von Entity Framework Core
            builder.Services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseInMemoryDatabase("MovieDb");
            });


            //Weitere Dienste kann man hier hinzufügen


            WebApplication app = builder.Build(); //Mit Build ist die Initialisierung zueende 
            #endregion

            #region Früheste Möglichkeit auf den IOC Container zuzugreifen -> Use Case -> Testdaten
            
            //.NET 2.1 -> Wenn wir EF Core frühstmöglich verwenden wollen, müssen wir mit CreateScope arbeiten 
            using (IServiceScope scope = app.Services.CreateScope())
            {
                ITimeService? timeService = scope.ServiceProvider.GetService<ITimeService>();
                ITimeService timeService2 = scope.ServiceProvider.GetRequiredService<ITimeService>();


                MovieDbContext context1 = scope.ServiceProvider.GetRequiredService<MovieDbContext>();

                DataSeeder.Seed(context1);
                //MovieDbContext context2 = scope.ServiceProvider.GetService<MovieDbContext>(); 
            }

            // Nach .NET 2.1
            ITimeService? timeService3 = app.Services.GetService<ITimeService>();
            ITimeService timeService4 = app.Services.GetRequiredService<ITimeService>();




            #region EF Core - BUG!!!!!

            //Geht
            //TimeService2? ts = app.Services.GetService<TimeService2>();

            //Geht nicht!!!!!!!!!!!!!!!!
            //MovieDbContext? context3 = app.Services.GetService<MovieDbContext>();
            //MovieDbContext context4 = app.Services.GetRequiredService<MovieDbContext>();
            #endregion


            #endregion


            #region Configurations-Part
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
            #endregion

            app.Run(); //WebApp läuft (hoffe 24/7) :-) 
        }
    }
}