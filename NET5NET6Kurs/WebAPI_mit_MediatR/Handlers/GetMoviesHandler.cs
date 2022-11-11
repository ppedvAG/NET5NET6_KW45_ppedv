using MediatR;
using WebAPI_mit_MediatR.Data;
using WebAPI_mit_MediatR.Models;
using WebAPI_mit_MediatR.Queries;

namespace WebAPI_mit_MediatR.Handlers
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMoviesHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore= fakeDataStore;
        }


        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            //Ab Hier könnten wir auch EF - Core verwenden (wäre aber ein Monolith) 
            
            return await _fakeDataStore.GetAllMovies();
        }
    }
}
