using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Analysis()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {         
           // var user = _userService.GetUserByEmail(User.Identity.Name);
           // ViewBag.username = user.FullName;
            return View();
        }

        

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

      

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
