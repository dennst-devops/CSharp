using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return View("Index");
            }
            else
            {
                return View("Dashboard");
            }
        }

        [HttpPost("createuser")]
        public IActionResult CreateUser(User newUser)
        {
            if (dbContext.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");
                return View("Index", newUser);
            }
            if (ModelState.IsValid)
            {
                User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.UserId == newUser.UserId);
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("SessionUserID", newUser.UserId);
                return RedirectToAction("Dashboard", HttpContext.Session.GetInt32("SessionUserID"));
            }
            else
            {
                return View("Index", newUser);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(User userSubmission)
        {

            WrapperViewModel myViewWrapperModel = new WrapperViewModel();
            myViewWrapperModel.LoggedInUser = dbContext.Users.FirstOrDefault(user => user.Email == userSubmission.Email);
            // myThing.AllUsers = ...
            User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.Email == userSubmission.Email);
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password (email)");
                return View("Index", userSubmission);
            }
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password (password)");
                return View("Index", userSubmission);
            }
            HttpContext.Session.SetInt32("SessionUserID", userInDb.UserId);
            return RedirectToAction("Dashboard");
            // return RedirectToAction("Index");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") != null)
            {
                WrapperViewModel allTheThings = new WrapperViewModel();
                allTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("SessionUserID"));
                allTheThings.AllWeddings = dbContext.Weddings.Include(w => w.Guests).ToList();
                allTheThings.AllUsers = dbContext.Users.Include(u => u.Weddings).ToList();
                return View("Dashboard", allTheThings);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            return View();
        }

        [HttpPost("createwedding")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            if (ModelState.IsValid)
            {
                newWedding.CreatedByID = (int)HttpContext.Session.GetInt32("SessionUserID");
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("WeddingDetails", newWedding);
            }
            else
            {
                return View("NewWedding");
            }
        }

        [HttpGet("{weddingID}")]
        public IActionResult WeddingDetails(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") != null)
            {
                WrapperViewModel allTheThings = new WrapperViewModel();
                allTheThings.OneWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingID);
                allTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("SessionUserID"));
                allTheThings.AllWeddings = dbContext.Weddings.Include(w => w.Guests).ToList();
                allTheThings.AllUsers = dbContext.Users.Include(u => u.Weddings).ToList();
                return View("WeddingDetails", allTheThings);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Delete/{myWeddingId}")]
        public IActionResult Delete(int myWeddingId)
        {
            Wedding OneWedding = dbContext.Weddings.FirstOrDefault(result => result.WeddingId == myWeddingId);
            dbContext.Weddings.Remove(OneWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
