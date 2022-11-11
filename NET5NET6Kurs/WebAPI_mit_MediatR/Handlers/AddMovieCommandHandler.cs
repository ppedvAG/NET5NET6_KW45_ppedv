using MediatR;
using WebAPI_mit_MediatR.Commands;
using WebAPI_mit_MediatR.Data;
using WebAPI_mit_MediatR.Models;
using WebAPI_mit_MediatR.Notifications;

namespace WebAPI_mit_MediatR.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        private readonly IMediator _mediator;
        public AddMovieHandler(IMediator mediator, FakeDataStore fakeDataStore)
        {
            _fakeDataStore= fakeDataStore;
            _mediator = mediator;
        }


        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddMovie(request.NewMovie);


            await _mediator.Publish(new MovieAddedNotification() { Movie = notification.Movie });
            return request.NewMovie;
        }
    }
}
