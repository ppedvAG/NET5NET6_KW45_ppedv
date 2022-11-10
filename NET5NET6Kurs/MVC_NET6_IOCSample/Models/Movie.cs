namespace MVC_NET6_IOCSample.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  

        public int Year { get; set; }
        public GenreType Genre { get; set; }
    }

    public enum GenreType { Action, Drama, Romance, Comedy, ScienceFiction, Horror, Thriller, Docu }
}
