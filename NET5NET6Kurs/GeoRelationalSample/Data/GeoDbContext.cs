using GeoRelationalSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoRelationalSample.Data
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext(DbContextOptions<GeoDbContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }


        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguagesInCountry> LanguagesInCountries { get; set; }

    }
}
