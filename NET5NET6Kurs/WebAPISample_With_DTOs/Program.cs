using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPISample_With_DTOs.Data;
namespace WebAPISample_With_DTOs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BookStoreDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDBContext") ?? throw new InvalidOperationException("Connection string 'BookStoreDBContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            using (IServiceScope scope = app.Services.CreateScope())
            {
                BookStoreDBContext ctx = scope.ServiceProvider.GetService<BookStoreDBContext>();

                DataSeeder.Seed(ctx);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}