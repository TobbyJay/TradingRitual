using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.Entities.Models;
using TradingRitual.DTO.ResponseDTOs;
using TradingRitual.DataAccess.Repository.Implementation;

namespace TradingRitual.Controllers
{
    public class FormController : Controller
    {
        private readonly TradingDbContext _context;
        private readonly IDataStore<Form> _formDataStore;
        private readonly IDataStore<Trader> _traderStore;

        public FormController(TradingDbContext context, IDataStore<Form> formDataStore, IDataStore<Trader> traderStore)
        {
            _context = context;
            _formDataStore = formDataStore;
            _traderStore = traderStore;
        }

        public IActionResult Index()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

          
            var strat = _context.Strategies.Where(s => s.TraderId == currentUser.TraderId).ToList();
            strat.Insert(0, new Strategy {
        
              Name = "Select a strategy "
            });

            ViewBag.Strategies = strat;
          

            var exitStrategies = _context.ExitStrategies.Where(s => s.TraderId == currentUser.TraderId).ToList();
            exitStrategies.Insert(0, new ExitStrategy
            {                
                Name = "Select an exit strategy"
            });

            ViewBag.ExitStrategies = exitStrategies;
           

          
            var pairs = _context.Pairs.Where(s => s.TraderId == currentUser.TraderId).ToList();
            pairs.Insert(0, new Pair
            {
                Currencies = "Select a pair",
                          
            });
            ViewBag.Pair = pairs;

            return View();
        }

        [HttpPost]
       
        public IActionResult PostForm(FormsViewModel model)
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            if (model == null)
            {
               // return Ok(new AuthResponse { Errror = "Formm did not get submitted" });
            }

            try
            {
       
                var createForm = new Form()
                {
                    
                    AcceptanceType = model.AcceptanceType,
                    DescribeTrade = model.DescribeTrade,
                    ExitStrategy = model.ExitStrategy,
                    ExplainTrade = model.ExplainTrade,
                    MentalState = model.MentalState,
                    MetDailyGoal = model.MetDailyGoal,
                    PairPicked = model.PairPicked,
                    RewardRatio = model.RewardRatio,
                    StrategyPicked = model.StrategyUsed,
                    TradingCriteria = model.TradingCriteria,
                    TradingTrend = model.TradingTrend,
                    TraderId  = currentUser.TraderId,
                    TimeOfTrade = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:tt"),
                    Note = model.Note,
                    TradeOutcome = model.TradeOutcome,
                    TradeStatus = model.TradeStatus

                    //DateTime.Now.ToString("MM/dd/yyyy h:mm tt")
                };
                _formDataStore.Post(createForm);
            }
            catch (Exception)
            {
                //throw;
               // return BadRequest(new AuthResponse { Errror = "form not created" });
            }
            return RedirectToAction("index","analysis");

        }
    }
}
