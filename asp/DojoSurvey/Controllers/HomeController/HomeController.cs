using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

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

        // [HttpPost]
        // [Route("method")]
        // public IActionResult Method()
        // {
        //     return View("result");
        // }

        [HttpPost("survey")]
        public IActionResult Submission(Survey survey)
        {
            // Survey mySurvey = new Survey()
            // {
            //     Name = ht_name,
            //     Location = ht_loc,
            //     Language = ht_lang,
            //     Comment = comment
            // };
            return View("Result", survey);
        }

    }
}