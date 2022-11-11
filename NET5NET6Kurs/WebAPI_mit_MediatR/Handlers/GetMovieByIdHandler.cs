using MediatR;
using WebAPI_mit_MediatR.Data;
using WebAPI_mit_MediatR.Models;
using WebAPI_mit_MediatR.Queries;

namespace WebAPI_mit_MediatR.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMovieByIdHandler(FakeDataStore fakeDataStore) 
            => _fakeDataStore = fakeDataStore;

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetMovieById(request.Id);    
        }
    }
}
