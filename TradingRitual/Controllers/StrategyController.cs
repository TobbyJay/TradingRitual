using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.DataAccess.Repository.Implementation;
using TradingRitual.DTO.RequestDTOs;
using TradingRitual.DTO.ResponseDTOs;
using TradingRitual.Entities.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Controllers
{
    public class StrategyController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStrategiesService _strategiesService;
        private readonly IDataStore<Trader> _traderStore;
        private readonly IDataStore<Strategy> _strategyStore;
        private readonly IDataStore<ExitStrategy> _exitStrategyStore;

        public StrategyController(IStrategiesService strategiesService, SignInManager<ApplicationUser> signInManager, IDataStore<Trader> traderStore, IDataStore<ExitStrategy> exitStrategyStore, IDataStore<Strategy> strategyStore)
        {
            _strategiesService = strategiesService;
            _signInManager = signInManager;
            _traderStore = traderStore;
            _exitStrategyStore = exitStrategyStore;
            _strategyStore = strategyStore;
        }


        /// <summary>
        /// This endpoint creates strategy
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostStrategy(PostEditPageViewModel model)
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            if (string.IsNullOrWhiteSpace(model.SimpleStrategyName))
            {
                return BadRequest(new AuthResponse { Errror = "Error,Strategy did not create!" });
            }

            try
            {
                var createStrategy = new Strategy
                {
                    Name = model.SimpleStrategyName,
                    Description = model.SimpleStrategyDescription,
                    TraderId = currentUser.TraderId
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
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));
            if (string.IsNullOrWhiteSpace(model.ExitStrategyName))
            {
                return BadRequest(new AuthResponse { Errror = "Error, exit Strategy did not create!" });
            }
            try
            {
                var createExitStrategy = new ExitStrategy
                {
                    Name = model.ExitStrategyName,
                    Description = model.ExitStrategyDescription,
                    TraderId = currentUser.TraderId

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

        [HttpGet]
        public ActionResult GetStrategy()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            var showStrategies = _strategiesService.GetAllStrategy(currentUser.TraderId);
            return Ok(showStrategies);
        }

        [HttpGet]
        public ActionResult GetExitStrategy()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            var showExitStrategies = _strategiesService.GetAllExitStrategy(currentUser.TraderId);
            return Ok(showExitStrategies);
        }

        [HttpGet]
        public ActionResult EditStrategy(Guid id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(userId));

            var strategy = _strategiesService.GetStrategy(id);
            ViewBag.id = id;
            if (strategy == null)
            {
                return NotFound();
            }
            else
            {
               
                return Ok(strategy);
            }



        }



        [HttpGet]
        public IActionResult Editstrategypage(Guid id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
               var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(userId));

           var strategy = _strategiesService.GetStrategy(id);
       
            ViewBag.id = id;

            if (strategy == null)
            {

            }
            EdiStrategyViewModel editStrategy = new EdiStrategyViewModel()
            {
                ID = strategy.StrategyID,
                SimpleStrategyName = strategy.Name,
                SimpleStrategyDescription = strategy.Description,
                TraderID = currentUser.TraderId
            };
            return View(editStrategy);
          
        }

        [HttpPost]
        public ActionResult Editstrategypage(EdiStrategyViewModel model)
        {
                Strategy strategy = _strategiesService.GetStrategy(model.ID);

                strategy.Name = model.SimpleStrategyName;
                strategy.Description = model.SimpleStrategyDescription;
                _strategyStore.Update(strategy);

                return Ok(strategy);
           
        }


        [HttpGet]
        public IActionResult EditExitStrategy(Guid id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(userId));

            var exitStrategy = _strategiesService.GetExitStrategy(id);

            ViewBag.id = id;

            

            if (exitStrategy == null)
            {

            }
            EditExitStrategyViewModel editStrategy = new EditExitStrategyViewModel()
            {
                ID = exitStrategy.ExitStrategyId,
                SimpleStrategyName = exitStrategy.Name,
                SimpleStrategyDescription = exitStrategy.Description,
                TraderID = currentUser.TraderId
            };
            return View(editStrategy);         
        }


        [HttpPost]
        public ActionResult EditExitStrategy(EditExitStrategyViewModel model)
        {
            ExitStrategy exitStrategy = _strategiesService.GetExitStrategy(model.ID);

            exitStrategy.Name = model.ExitStrategyName;
            exitStrategy.Description = model.ExitStrategyDescription;
            _exitStrategyStore.Update(exitStrategy);

            return Ok(exitStrategy);

        }


    }
}
