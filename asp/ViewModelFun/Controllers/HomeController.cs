using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Message myString = new Message()
            {
                TheMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lobortis scelerisque fermentum dui faucibus in. Non arcu risus quis varius. Posuere ac ut consequat semper. Aliquam sem et tortor consequat id. Urna neque viverra justo nec ultrices dui sapien eget. Leo vel fringilla est ullamcorper. Praesent elementum facilisis leo vel fringilla est ullamcorper eget."
            };
            return View(myString);
        }

        [HttpGet]
        [Route("Numbers")]

        public IActionResult Numbers()
        {
            Number someNumbers = new Number()
            {
                MyNumber = 2
            };
            int[] myNums = new int[]
            {
                1,2,3,4,5
            };
            return View(myNums);
        }

        [HttpGet]
        [Route("Users")]
        public IActionResult Users()
        {
            User someUser = new User()
            {
                FirstName = "Dave",
                LastName = "Lister"
            };
            User nextUser = new User()
            {
                FirstName = "Kryten",
                LastName = "Android"
            };
            User lastUser = new User()
            {
                FirstName = "Arnold",
                LastName = "Rimmer"
            };
            List<User> viewModel = new List<User>()
            {
                someUser, nextUser, lastUser
            };
            return View(viewModel);
        }

        [HttpGet]
        [Route("Userx")]
        public IActionResult Userx()
        {
            User oneUser = new User()
            {
                FirstName = "Holly",
                LastName = "Gram"
            };
            return View(oneUser);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
