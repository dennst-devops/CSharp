using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace ProductsAndCategories.Controllers
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
            return View();
        }


        [HttpGet("CategoryDetails/{categoryID}")]
        public IActionResult CategoryDetails(int categoryID)
        {
            ViewBag.AllProds = dbContext.Products.ToList();
            Category thisCat = dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryID);
            return View(thisCat);
        }

        [HttpGet("ProductDetails/{productId}")]
        public IActionResult ProductDetails(int productId)
        {
            ViewBag.AllCats = dbContext.Categories.ToList();
            Product thisProd = dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(thisProd);
        }

        [HttpGet("Products")]
        public IActionResult Products()
        {
            ViewBag.AllProds = dbContext.Products.ToList();
            return View();
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCats = dbContext.Categories.ToList();
            return View();
        }


        [HttpPost("createproduct")]
        public IActionResult CreateProduct(Product newProd)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(newProd);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                return View("Products");
            }
        }

        [HttpPost("createcategory")]
        public IActionResult CreateCategory(Category newCat)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(newCat);
                dbContext.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                return View("Categories");
            }
        }

        ////////////////////////////////////////////

        // [HttpGet("ProductDetails2/{productId}")]
        // public IActionResult NoProductDetails(int id, Product prodtoedit)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         prodtoedit.ProductId = id;
        //         dbContext.Update(prodtoedit);
        //         dbContext.Entry(prodtoedit).Property("CreatedAt").IsModified = false;
        //         dbContext.SaveChanges();
        //         return View();
        //     }
        //     else
        //     {
        //         return View();
        //     }
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
