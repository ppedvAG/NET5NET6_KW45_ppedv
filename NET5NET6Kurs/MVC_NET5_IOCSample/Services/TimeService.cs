using System;

namespace MVC_NET5_IOCSample.Services
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

}
