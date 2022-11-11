using System.Runtime.CompilerServices;
using WebAPISample_With_DTOs.Models;

namespace WebAPISample_With_DTOs.Data
{
    public static class DataSeeder
    {
        public static void Seed(BookStoreDBContext context)
        {

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
              new Author() { Name = "Jane Austen" },
                      new Author() { Name = "Charles Dickens" },
                      new Author() { Name = "Miguel de Cervantes" }

                );

                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
               new Book()
               {

                   Title = "Pride and Prejudice",
                   Year = 1813,
                   AuthorId = context.Authors.First().Id,
                   Price = 9.99M,
                   Genre = "Comedy of manners"
               },
               new Book()
               {
                   Title = "Northanger Abbey",
                   Year = 1817,
                   AuthorId = context.Authors.First(x => x.Id == 2).Id,
                   Price = 12.95M,
                   Genre = "Gothic parody"
               },
               new Book()
               {
                   Title = "David Copperfield",
                   Year = 1850,
                   AuthorId = context.Authors.First(x => x.Id == 2).Id,
                   Price = 15,
                   Genre = "Bildungsroman"
               },
               new Book()
               {
                   Title = "Don Quixote",
                   Year = 1617,
                   AuthorId = context.Authors.First().Id,
                   Price = 8.95M,
                   Genre = "Picaresque"
               }
               );

                context.SaveChanges();
            }
        }
    }
}
