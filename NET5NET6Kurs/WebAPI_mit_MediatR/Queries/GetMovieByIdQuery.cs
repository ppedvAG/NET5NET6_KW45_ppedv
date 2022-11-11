using MediatR;
using WebAPI_mit_MediatR.Models;

namespace WebAPI_mit_MediatR.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public int Id { get; set; }
    }

    //public record GetMovieByIdQueryRecord(int Id) : IRequest<Movie>;
}
