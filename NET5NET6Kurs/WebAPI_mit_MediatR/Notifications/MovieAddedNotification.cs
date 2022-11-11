using MediatR;
using WebAPI_mit_MediatR.Models;

namespace WebAPI_mit_MediatR.Notifications
{
    public class MovieAddedNotification : INotification
    {
        public Movie Movie { get; set; }
    }
}
