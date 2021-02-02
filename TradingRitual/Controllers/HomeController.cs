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
using TradingRitual.Helpers.ContextAccessor;

namespace TradingRitual.Controllers
{
    public class HomeController : Controller
    {
       // private readonly Guid _TraderId;
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IStrategiesService _strategiesService;
        private readonly IFormService _formService;
        private readonly IDataStore<Pair> _pairStore;
        private readonly IDataStore<TradingHours> _tradeTimeStore;
        private readonly IDataStore<Trader> _traderStore;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDataStore<Strategy> _strategyStore;
        private readonly IContextAccessor _contextAccessor;

        private readonly IPairsService _pairsService;

        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService,
            SignInManager<ApplicationUser> signInManager,

            IDataStore<Pair> pairStore,
            IDataStore<ExitStrategy> exitStrategyStore,
            IDataStore<TradingHours> tradeTimeStore,
            IContextAccessor contextAccessor,
            IDataStore<Trader> traderStore,
            IStrategiesService strategiesService,
            IPairsService pairsService, IFormService formService, IDataStore<Strategy> strategyStore)
        {
            _logger = logger;
            _userService = userService;
            _signInManager = signInManager;
            _pairStore = pairStore;
            _tradeTimeStore = tradeTimeStore;
            // _TraderId = contextAccessor.GetTraderId();

            _traderStore = traderStore;
            _strategiesService = strategiesService;
            _pairsService = pairsService;
            _formService = formService;
            _strategyStore = strategyStore;
        }


        [HttpGet]
    

        [HttpGet]
        public IActionResult Index()

        {
            

            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            var getPairs = _pairsService.GetPairs(currentUser.TraderId);
            var getWins = _formService.GetWins(currentUser.TraderId);
            var getLosses = _formService.GetLosses(currentUser.TraderId);
            var getMiniAnalysis = _formService.GetAnalysisForDashboard(currentUser.TraderId, 1);

            var dashboardDetails = new DashboardViewModel()
            {
                Pairs = getPairs,
                AnalysisDetails = getMiniAnalysis,
                TradeWins = getWins,
                TradeLosses = getLosses,
                

            };

            var tenantId = currentUser.TraderId;
            ViewBag.TraderId = tenantId;
            return View(dashboardDetails);
        }

       
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Analysis()
        {
            return View();
        }

     


        /// <summary>
        /// This endpoint creates and sets trading hours
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostTradingHours(PostEditPageViewModel model)
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            if (string.IsNullOrWhiteSpace(model.StartTime))
            {
                return BadRequest(new AuthResponse { Errror = "Error, trading hours not set!" });
            }

            try
            {

                var createTradingHours = new TradingHours
                {
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    TraderId = currentUser.TraderId

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





        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
