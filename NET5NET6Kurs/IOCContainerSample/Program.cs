using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerSample;

internal class Program
{
    static void Main(string[] args)
    {
        #region Initialisierung - Phase 
        //Die ServiceCollection nimmt alle Services (z.b TimeService) auf. 
        IServiceCollection collection = new ServiceCollection();

        collection.AddSingleton<ITimeService, TimeService>(); //Dependency Inversion -> Solid-Regel (Interface mit Klasse) 

        //Initialisierungphase ist mit folgendem Befehl zueende (IServiceProvider, ServiceProvider) 
        IServiceProvider provider = collection.BuildServiceProvider();
        #endregion

        #region Zugriff auf den IOC Container
        //Zugriff: 

        //Variante1: 

        //Bei nichtfinden eines Services, wird NULL zurück gegeben
        ITimeService? timeService = provider.GetService<ITimeService>();

        //Variante2: -> bei nichtfinden eines Services wird eine Exception ausgegeben 
        TimeService timeService1 = provider.GetRequiredService<TimeService>();
        #endregion
    }
}


public interface ITimeService
{
    string GetCurrentTime();
}

public class TimeService : ITimeService
{
    string currentDateTime;


    //Wenn der Konstruktor augerufen wird, möchte ich die Uhrzeit auslesen 
    public TimeService() 
    {
        currentDateTime = DateTime.Now.ToShortTimeString();
    }

    public string GetCurrentTime()
    {
        return currentDateTime;
    }
}
