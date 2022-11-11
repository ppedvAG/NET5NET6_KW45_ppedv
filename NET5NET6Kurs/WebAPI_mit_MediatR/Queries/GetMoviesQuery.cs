using MediatR;
using WebAPI_mit_MediatR.Models;

namespace WebAPI_mit_MediatR.Queries
{
    public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
    {
    }
}
