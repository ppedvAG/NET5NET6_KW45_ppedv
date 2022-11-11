using MediatR;
using System.Diagnostics;
using WebAPI_mit_MediatR.Data;
using WebAPI_mit_MediatR.Notifications;

namespace WebAPI_mit_MediatR.Handlers
{
    public class EmailHandler : INotificationHandler<MovieAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        private readonly IMediator _mediator;

        public EmailHandler(IMediator mediator, FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
            _mediator = mediator;
        }


        public async Task Handle(MovieAddedNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("EmailHandler is called");
            await _fakeDataStore.EventOccured(notification.Movie, "Email sent");

            

            await Task.CompletedTask;
        }
    }


    public class CacheInvalidationHandler : INotificationHandler<MovieAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(MovieAddedNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("CacheInvalidationHandler is called");
            await _fakeDataStore.EventOccured(notification.Movie, "Cache Invalidated");

            await Task.CompletedTask;
        }
    }
}
