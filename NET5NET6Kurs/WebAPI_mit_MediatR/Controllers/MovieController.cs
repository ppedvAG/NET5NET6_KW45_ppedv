using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_mit_MediatR.Commands;
using WebAPI_mit_MediatR.Models;
using WebAPI_mit_MediatR.Notifications;
using WebAPI_mit_MediatR.Queries;

namespace WebAPI_mit_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMediator _meditor;

        public MovieController(IMediator mediator)
        {
            _meditor = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            //_mediator.Send(new GetMoviesQuery()) -> Gebe mir alle Filme zurück
            IEnumerable<Movie> movies = await _meditor.Send(new GetMoviesQuery());

            return Ok(movies);
        }

        [HttpGet("{id:int?}", Name = "GetMovieById")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            Movie movie = await _meditor.Send(new GetMovieByIdQuery() { Id = id });

            return Ok(movie);
        }


        [HttpPost]
        public async Task<ActionResult> AddMovie(Movie movie)
        {
            //Workflow 1 -> Film wird hinzugefügt

            Movie movieWithId = await _meditor.Send(new AddMovieCommand() { NewMovie = movie });

            //Mitteilungen raussenden
            await _meditor.Publish(new MovieAddedNotification() { Movie = movieWithId });

            return CreatedAtRoute("GetMovieById", new { id = movieWithId.Id }, movieWithId);

        }

    }
}
