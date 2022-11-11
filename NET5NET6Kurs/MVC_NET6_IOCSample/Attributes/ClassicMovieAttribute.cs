using MVC_NET6_IOCSample.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_NET6_IOCSample.Attributes
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public int Year { get; set; }

        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }

        public string GetErrorMessage() =>
            $"Klassiker Filme sind vor dem Jahr {Year} erschienen";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;

            int releaseYear = (int)value!; 

            if (movie.Genre == GenreType.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
