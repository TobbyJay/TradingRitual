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
using TradingRitual.DTO.RequestDTOs;
using TradingRitual.DTO.ResponseDTOs;
using TradingRitual.Entities.Models;
using TradingRitual.DataAccess.Repository.Implementation;

namespace TradingRitual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IDataStore<Strategy> _strategyStore;
        private readonly IDataStore<ExitStrategy> _exitStrategyStore;
        private readonly IDataStore<Pair> _pairStore;
        private readonly IDataStore<TradingHours> _tradeTimeStore;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService,
            SignInManager<ApplicationUser> signInManager,
            IDataStore<Strategy> strategyStore,
            IDataStore<Pair> pairStore, 
            IDataStore<ExitStrategy> exitStrategyStore, 
            IDataStore<TradingHours> tradeTimeStore)
        {
            _logger = logger;
            _userService = userService;
            _signInManager = signInManager;
            _strategyStore = strategyStore;
            _pairStore = pairStore;
            _exitStrategyStore = exitStrategyStore;
            _tradeTimeStore = tradeTimeStore;
        }


        [HttpGet]
        public IActionResult Analysis()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {        
            return View();
        }

        

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// This endpoint creates strategy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostStrategy(PostEditPageViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.SimpleStrategyName))
            {
                return BadRequest(new AuthResponse { Errror = "Error,Strategy did not create!" });
            }

            try
            {
               
                    var createStrategy = new Strategy
                    {
                            Name = model.SimpleStrategyName,
                            Description = model.SimpleStrategyDescription
                           // CheckList = model.SimpleStrategyCheckLists                           
                    };
                    _strategyStore.Post(createStrategy);
          
            }
            catch (Exception)
            {
                return BadRequest(new AuthResponse { Errror = "strategy not created" });
                //throw;
            }

            return Ok(model);

        }

        /// <summary>
        /// This endpoint creates exit strategy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostExitStrategy(PostEditPageViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ExitStrategyName))
            {
                return BadRequest(new AuthResponse { Errror = "Error, exit Strategy did not create!" });
            }

            try
            {

               
                    var createExitStrategy = new ExitStrategy
                    {
                        Name = model.ExitStrategyName,
                        Description = model.ExitStrategyDescription

                    };
                    _exitStrategyStore.Post(createExitStrategy);
            

            }
            catch (Exception)
            {
                return BadRequest(new AuthResponse { Errror = " exit strategy not created" });
                //throw;
            }

            return Ok(model);

        }

        /// <summary>
        /// This endpoint creates pairs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostPairs(PostEditPageViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Base))
            {
                return BadRequest(new AuthResponse { Errror = "Error,pairs did not create!" });
            }

            try
            {
               
                    var createPair = new Pair
                    {
                        Currencies = $"{model.Base} {model.Quote}"

                    };
                    _pairStore.Post(createPair);

            }
            catch (Exception)
            {
                return BadRequest(new AuthResponse { Errror = " pairs not created" });
                //throw;
            }

            return Ok(model);

        }
        /// <summary>
        /// This endpoint creates and sets trading hours
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostTradingHours(PostEditPageViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.StartTime))
            {
                return BadRequest(new AuthResponse { Errror = "Error, trading hours not set!" });
            }

            try
            {

                var createTradingHours = new TradingHours
                {
                     StartTime = model.StartTime,
                     EndTime = model.EndTime

                };
                _tradeTimeStore.Post(createTradingHours);

            }
            catch (Exception)
            {
                return BadRequest(new AuthResponse { Errror = " trading hours not set" });
                //throw;
            }

            return Ok(model);

        }

        //private AuthResponse PostExit(PostEditPageViewModel model)
        //{
        //    if (string.IsNullOrWhiteSpace(model.SimpleStrategyName))
        //    {
        //        return new AuthResponse { Errror = "Error,Exit Strategy did not create!" };
        //    }

        //    try
        //    {              
        //            var createExitStrategy = new ExitStrategy
        //            {
        //                Name = model.SimpleStrategyName,
        //                Description = model.SimpleStrategyDescription
        //                // CheckList = model.SimpleStrategyCheckLists
        //            };
        //            _exitStrategyStore.Post(createExitStrategy);


        //    }
        //    catch (Exception)
        //    {
        //        return new AuthResponse { Errror = " Exit strategy not created" };
        //        //throw;
        //    }

        //    return new AuthResponse { Errror = "creation successful" };
        //}

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
