using MediatR;
using WebAPI_mit_MediatR.Models;

namespace WebAPI_mit_MediatR.Commands
{
    public class AddMovieCommand : IRequest<Movie> //Hinzugefügtes Movie mit Id (nach dem Speichern mit Id zurückgegeben) 
    {
        //Übergabe eines Movies zum hinzufügen in DB ohne Id 
        public Movie NewMovie { get; set; }
    }

    //public interface ICommandRequest<T> : IRequest<T> 
    //{ 
    //    //
    //}

    //public record AddMovieCommand(Movie Movie) : ICommandRequest<Movie>;
}
