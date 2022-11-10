namespace MVC_NET6_IOCSample.Data
{
    public static class DataSeeder
    {

        public static void Seed(MovieDbContext context)
        {
            if(!context.Movies.Any())
            {
                context.Movies.Add(new Models.Movie { Title = "Jurassic Park", Description = "TRex kann man streicheln", Price = 10, Genre = Models.GenreType.ScienceFiction});
                context.Movies.Add(new Models.Movie { Title = "Jurassic Park 2", Description = "TRex ist veggie", Price = 11, Genre = Models.GenreType.ScienceFiction });
                context.Movies.Add(new Models.Movie { Title = "Jurassic Park 3", Description = "Dinosauerier züchten Menschen", Price = 12, Genre = Models.GenreType.ScienceFiction });
                context.Movies.Add(new Models.Movie { Title = "Batman", Description = "Joker und Batman gründen eine WG", Price = 10, Genre = Models.GenreType.ScienceFiction });
                context.Movies.Add(new Models.Movie { Title = "Heidi", Description = "in der Schweiz", Price = 10, Genre = Models.GenreType.ScienceFiction });


                context.SaveChanges(); //Hier wird das SQL gegenüber der DB übertragen 
            }
        }
    }
}
