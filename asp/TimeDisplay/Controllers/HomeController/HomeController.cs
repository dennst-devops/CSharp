using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay
{
    
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}