using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPISample_With_DTOs.Models;

namespace WebAPISample_With_DTOs.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext (DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPISample_With_DTOs.Models.Author> Authors { get; set; } = default!;

        public DbSet<WebAPISample_With_DTOs.Models.Book> Books { get; set; }
    }
}
