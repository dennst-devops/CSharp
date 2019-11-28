using Microsoft.AspNetCore.Mvc;

namespace RazorFun
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