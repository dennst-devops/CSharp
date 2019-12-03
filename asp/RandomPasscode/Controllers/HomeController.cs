using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;



namespace RandomPasscode.Controllers
{

    public class HomeController : Controller
    {
        private int? SessionCount
        {
            get { return HttpContext.Session.GetInt32("count"); }
            set { HttpContext.Session.SetInt32("count", (int)value); }
        }

        private string SessionPassCode
        {
            get { return HttpContext.Session.GetString("passcode"); }
            set { HttpContext.Session.SetString("passcode", value); }
        }


        public IActionResult Index()
        {
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            if (ViewBag.Count >= 0)
            {
                // ViewBag.Count += 1;
                SessionCount++;
            }
            else
            {
                // ViewBag.Count = 1;
                SessionCount = 1;
            }

            {
                ViewBag.Count = SessionCount;
            }
            ViewBag.passcode = SessionPassCode;
            return View();
        }

        public string GeneratePasscode()
        {
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            string Result = "";
            Random rand = new Random();
            for (var i = 1; i <= 15; i++)
            {
                Result +=Chars[rand.Next(Chars.Length)];
            }
            return Result;
        }


        [HttpPost("generate")]
        public IActionResult Generate()
        {
            // SessionCount++;
            SessionPassCode = GeneratePasscode();

            return RedirectToAction("Index");
        }


        [HttpPost("reset")]
        public IActionResult Reset()
        {
            // HttpContext.Session.Clear();
            HttpContext.Session.Remove("count");
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
