using Microsoft.Extensions.DependencyInjection;

namespace MVC_NET6_IOCSample.Services
{
    public static class TimeServiceExtention
    {
        public static void AddTimeService(this IServiceCollection collection)
        {
            collection.AddSingleton<ITimeService, TimeService>();
        }
        
    }
}
