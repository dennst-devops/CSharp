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
                return RedirectToAction("Dashboard", HttpContext.Session.GetInt32("SessionUserID"));
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
                //User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.UserId == newUser.UserId);
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("SessionUserID", newUser.UserId);
                return RedirectToAction("Dashboard");
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
            // User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.Email == userSubmission.Email);
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password (email)");
                return View("Index", userSubmission);
            }
            if (userSubmission.Password == null)
            {
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
                allTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(user => user.UserId == (int)HttpContext.Session.GetInt32("SessionUserID"));
                allTheThings.AllWeddings = dbContext.Weddings.Include(w => w.Guests).ToList();
                allTheThings.AllUsers = dbContext.Users.Include(u => u.Weddings).ToList();
                return View("Dashboard", allTheThings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("createwedding")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
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
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }

            WrapperViewModel allTheThings = new WrapperViewModel();
            allTheThings.OneWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingID);
            allTheThings.LoggedInUser = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("SessionUserID"));
            allTheThings.AllWeddings = dbContext.Weddings.Include(w => w.Guests).ToList();
            allTheThings.AllUsers = dbContext.Users.Include(u => u.Weddings).ToList();

            if (allTheThings.OneWedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            return View("WeddingDetails", allTheThings);
        }

        [HttpGet("Delete/{myWeddingId}")]
        public IActionResult Delete(int myWeddingId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding OneWedding = dbContext.Weddings.FirstOrDefault(result => result.WeddingId == myWeddingId);
            if (OneWedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            if (OneWedding.CreatedByID != HttpContext.Session.GetInt32("SessionUserID"))
            {
                return RedirectToAction("Dashboard");
            }
            dbContext.Weddings.Remove(OneWedding);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("rsvp/{weddingID}")]
        public IActionResult Rsvp(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }

            WrapperViewModel allTheThings = new WrapperViewModel();
            allTheThings.OneConnector = new Connector();

            allTheThings.OneConnector.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            allTheThings.OneConnector.WeddingId = weddingID;
            // Wedding OneWedding = dbContext.Weddings.FirstOrDefault(result => result.WeddingId == weddingID);
            Wedding OneWedding = dbContext.Weddings.Include(r => r.Guests).FirstOrDefault(r => r.WeddingId == weddingID);
            if (OneWedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            if (OneWedding.CreatedByID == (int)HttpContext.Session.GetInt32("SessionUserID") || OneWedding.Guests.Any(r => r.UserId == (int)HttpContext.Session.GetInt32("SessionUserID")))
            {
                return RedirectToAction("Dashboard");
            }

            dbContext.Add(allTheThings.OneConnector);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpGet("UnRSVP/{weddingID}")]
        public IActionResult UnRSVP(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModel allTheThings = new WrapperViewModel();
            allTheThings.OneConnector = new Connector();

            allTheThings.OneConnector.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            allTheThings.OneConnector.WeddingId = weddingID;
            Connector thisRsvp = dbContext.Connectors.FirstOrDefault(w => w.WeddingId == weddingID && w.UserId == allTheThings.OneConnector.UserId);
            if(thisRsvp == null)
            {
                return RedirectToAction("Dashboard");
            }
            Wedding OneWedding = dbContext.Weddings.FirstOrDefault(result => result.WeddingId == weddingID);
            if (OneWedding == null)
            {
                return RedirectToAction("Dashboard");
            }

            dbContext.Remove(thisRsvp);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("edit/{weddingID}")]
        public IActionResult EditWedding(int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            WrapperViewModel allTheThings = new WrapperViewModel();
            allTheThings.OneConnector = new Connector();

            allTheThings.OneConnector.UserId = (int)HttpContext.Session.GetInt32("SessionUserID");
            allTheThings.OneConnector.WeddingId = weddingID;
            allTheThings.OneWedding = dbContext.Weddings.FirstOrDefault(r => r.WeddingId == weddingID);
            // Wedding OneWedding = dbContext.Weddings.FirstOrDefault(result => result.WeddingId == weddingID);
            Wedding OneWedding = dbContext.Weddings.Include(r => r.Guests).FirstOrDefault(r => r.WeddingId == weddingID);
            if (OneWedding == null)
            {
                return RedirectToAction("Dashboard");
            }
            // if (OneWedding.CreatedByID == (int)HttpContext.Session.GetInt32("SessionUserID") || OneWedding.Guests.Any(r => r.UserId == (int)HttpContext.Session.GetInt32("SessionUserID")))
            // {
            //     return RedirectToAction("Dashboard");
            // }

            // dbContext.Add(allTheThings.OneConnector);
            // dbContext.SaveChanges();

            return View("EditWedding", OneWedding);
        }

        [HttpPost("updatewedding/{WeddingId}")]
        public IActionResult UpdateWedding(Wedding weddingToUpdate, int weddingID)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                WrapperViewModel allTheThings = new WrapperViewModel();
                allTheThings.OneWedding = dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingID);
                allTheThings.OneWedding.WedderOne = weddingToUpdate.WedderOne;
                allTheThings.OneWedding.WedderTwo = weddingToUpdate.WedderTwo;
                allTheThings.OneWedding.WeddingDate = weddingToUpdate.WeddingDate;
                allTheThings.OneWedding.Address = weddingToUpdate.Address;
                allTheThings.OneWedding.UpdatedAt = DateTime.Now; 
                dbContext.SaveChanges();
                return RedirectToAction("WeddingDetails", new { weddingID = weddingID });
            }
            else
            {
                return View("NewWedding");
            }
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
