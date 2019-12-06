using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginAndReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginAndReg.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return View("Index");
            }
            else
            {
                return View("Success");
            }
            
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult LoginPage()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return View("Login");
            }
            else
            {
                return View("Success");
            }

        }

        // [HttpPost]
        // [Route("Login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dbContext.Things.FirstOrDefault(u => u.Email == userSubmission.Email);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password (email)");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if (result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password (password)");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("SessionUserID", userInDb.ThingId);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            //check for session

            if (HttpContext.Session.GetInt32("SessionUserID") != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("create")]
        public IActionResult Create(Thing newThing)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<Thing> Hasher = new PasswordHasher<Thing>();
                newThing.Password = Hasher.HashPassword(newThing, newThing.Password);
                dbContext.Things.Add(newThing);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("SessionUserID", newThing.ThingId);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index", newThing);
            }
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
