using System;

namespace MVC_NET6_IOCSample.Services
{
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


    public class TimeService2
    {
        string currentDateTime;


        //Wenn der Konstruktor augerufen wird, möchte ich die Uhrzeit auslesen 
        public TimeService2()
        {
            currentDateTime = DateTime.Now.ToShortTimeString();
        }

        public string GetCurrentTime()
        {
            return currentDateTime;
        }
    }

}
