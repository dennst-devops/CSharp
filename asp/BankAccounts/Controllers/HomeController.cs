using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BankAccounts.Controllers
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
                return View("Account");
            }
        }

        [HttpPost("create")]
        public IActionResult Create(User newUser)
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
                return RedirectToAction("ViewAccount", HttpContext.Session.GetInt32("SessionUserID"));
            }
            else
            {
                return View("Index", newUser);
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("SessionUserID") == null)
            {
                return View("Login");
            }
            else
            {
                return View("Account", HttpContext.Session.GetInt32("SessionUserID"));
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(User userSubmission)
        {
            User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.Email == userSubmission.Email);
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password (email)");
                return View("Login", userSubmission);
            }
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password (password)");
                return View("Login", userSubmission);
            }
            HttpContext.Session.SetInt32("SessionUserID", userInDb.UserId);
            return RedirectToAction("Account", RetrievedUser);
        }

        [HttpGet("Account/{userId}")]
        public IActionResult Account(int userId)
        {
            if (HttpContext.Session.GetInt32("SessionUserID") != null)
            {
                User RetrievedUser = dbContext.Users.FirstOrDefault(user => user.UserId == userId);
                return View("Account", RetrievedUser);
            }
            else
            {
                return View("Index");
            }
        }



        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        ///////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
