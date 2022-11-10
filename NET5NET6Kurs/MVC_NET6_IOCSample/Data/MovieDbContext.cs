using Microsoft.EntityFrameworkCore;
using MVC_NET6_IOCSample.Models;

namespace MVC_NET6_IOCSample.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) 
            : base(options)
        {

        }


        //Propertyname gibt den Tabellennamen bei CodeFirst vor 
        public DbSet<Movie> Movies { get; set; }
    }
}
