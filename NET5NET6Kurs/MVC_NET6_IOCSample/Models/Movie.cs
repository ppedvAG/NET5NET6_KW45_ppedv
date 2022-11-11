using MVC_NET6_IOCSample.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MVC_NET6_IOCSample.Models
{
    /*
     * DataAnnotations: 
     * Kriterien werden am Model als Attribute hinterlegt 
     * Wirkt sich gegenüber UI und DB aus.     
     */


    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Range(0.1, 100)]
        public decimal Price { get; set; }


        [ClassicMovie(1970)]
        public int Year { get; set; } 
        public GenreType Genre { get; set; }
    }

    public enum GenreType { Action, Drama, Romance, Comedy, ScienceFiction, Horror, Thriller, Docu, Classic  }
}
