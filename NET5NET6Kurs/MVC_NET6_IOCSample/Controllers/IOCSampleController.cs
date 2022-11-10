using Microsoft.AspNetCore.Mvc;
using MVC_NET6_IOCSample.Services;

namespace MVC_NET6_IOCSample.Controllers
{

    /*
     * Zugriff auf IOC Container (Dependency Injection) 
     * 
     * Sample1: Konstruktor-Injection: Für klassenweite Verwendung
     * 
     * 
     */ 

    public class IOCSampleController : Controller
    {
        private ILogger<IOCSampleController> logger;


        //Konstruktor-Injection
        public IOCSampleController(ILogger<IOCSampleController> logger)
        {
            this.logger = logger;
        }
        

        //Methoden-Injection 
        public IActionResult Sample1([FromServices] ITimeService timeService)
        {
            logger.LogInformation("Call Sample1");

            
            return View(model: timeService.GetCurrentTime());
        }

        //Zugriff via HTTPCONTEXT
        public async Task<IActionResult> Sample2()
        {
            logger.LogInformation("Call Sample2");

            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            ITimeService timeService1 = HttpContext.RequestServices.GetRequiredService<ITimeService>();

            return View();
        }

        public IActionResult Sample3()
        {
            return View(); 
        }




    }
}
