using ConsoleWithEFCoreSample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithEFCoreSample.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);

            DbConnectionStringBuilder dbConnectionStringBuilder = new DbConnectionStringBuilder();
            dbConnectionStringBuilder.ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=SchoolDB123;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(dbConnectionStringBuilder.ToString());
        }
    }
}
