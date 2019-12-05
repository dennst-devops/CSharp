using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
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
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            return View(AllDishes);
        }

        [HttpGet("New")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpPost("update/{myDishID}")]
        public IActionResult Update(int myDishID, Dish myDish)
        {
            Dish OneDish = dbContext.Dishes.FirstOrDefault(result => result.DishID == myDishID);
            if (ModelState.IsValid)
            {
                OneDish.Name = myDish.Name;
                OneDish.Chef = myDish.Chef;
                OneDish.Calories = myDish.Calories;
                OneDish.Tastiness = myDish.Tastiness;
                OneDish.Description = myDish.Description;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit/{myDishID}");
            }
        }
        [HttpGet("Edit/{myDishID}")]
        public IActionResult Edit(int myDishID)
        {
            Dish OneDish = dbContext.Dishes.FirstOrDefault(result => result.DishID == myDishID);
            return View("Edit", OneDish);
        }

        [HttpGet("{myDishID}")]
        public IActionResult Details(int myDishID)
        {
            Dish OneDish = dbContext.Dishes.FirstOrDefault(result => result.DishID == myDishID);
            return View("Details", OneDish);
        }

        [HttpGet("Delete/{myDishID}")]
        public IActionResult Delete(int myDishID)
        {
            Dish OneDish = dbContext.Dishes.FirstOrDefault(result => result.DishID == myDishID);
            dbContext.Dishes.Remove(OneDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
