using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroStuff.Sessions.Controllers
{
    [Route("health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return new HttpStatusCodeResult(200);
        }
    }
}
