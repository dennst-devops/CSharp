using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("method")]
        public IActionResult Method(string ht_name, string ht_loc, string ht_lang, string comment)
        {
            ViewBag.Name = ht_name;
            ViewBag.Loc = ht_loc;
            ViewBag.Lang = ht_lang;
            ViewBag.Comment = comment;
            return View("Result");
        }
    }
}