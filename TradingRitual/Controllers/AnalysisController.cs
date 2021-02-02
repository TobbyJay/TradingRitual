using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.DataAccess.Repository.Implementation;
using TradingRitual.DTO.ResponseDTOs;
using TradingRitual.Entities.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly TradingDbContext _context;
        private readonly IAnalysisService _analysisService;
        private readonly IDataStore<Trader> _traderStore;
        private readonly IDataStore<Form> _analysisStore;
        public AnalysisController(IAnalysisService analysisService, IDataStore<Trader> traderStore, TradingDbContext context, IDataStore<Form> analysisStore)
        {
            _analysisService = analysisService;
            _traderStore = traderStore;
            _context = context;
            _analysisStore = analysisStore;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));
            var getAnalysis = _analysisService.GetAllAnalysis(currentUser.TraderId);

            var analysis = new AnalysisViewModel
            {
                 FormData = getAnalysis
            };

            return View(analysis);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var getAnalysis = _analysisStore.GetById(id);
          
            var getAnalysisDetails = new FormsViewModel()
            {

                StrategyUsed = getAnalysis.StrategyPicked,
                TradingCriteria = getAnalysis.TradingCriteria,
                ExitStrategy = getAnalysis.ExitStrategy,
                TradingTrend = getAnalysis.TradingTrend,
                AcceptanceType = getAnalysis.AcceptanceType,
                RewardRatio = getAnalysis.RewardRatio,
                DescribeTrade = getAnalysis.DescribeTrade,
                PairPicked = getAnalysis.PairPicked,
                MentalState = getAnalysis.MentalState,
                TradeStatus = getAnalysis.TradeStatus,
                TradeOutcome = getAnalysis.TradeOutcome,
                TimeOfTrade = getAnalysis.TimeOfTrade,
                ExplainTrade = getAnalysis.ExplainTrade,
                Note = getAnalysis.Note,
                MetDailyGoal = getAnalysis.MetDailyGoal
                
            };

            return View(getAnalysisDetails);
           
        }

        [HttpGet]

        public IActionResult EditAnalysis(Guid id)
        {

            List<Strategy> strategy = new List<Strategy>();

            strategy = (from c in _context.Strategies select c).ToList();
            strategy.Insert(0, new Strategy
            {

                Name = "Select a strategy "
            });
            ViewBag.Strategies = strategy;


            List<ExitStrategy> exitStrategies = new List<ExitStrategy>();
            exitStrategies = (from c in _context.ExitStrategies select c).ToList();
            exitStrategies.Insert(0, new ExitStrategy
            {

                Name = "Select an exit strategy"
            });
            ViewBag.ExitStrategies = exitStrategies;


            List<Pair> pairs = new List<Pair>();
            pairs = (from c in _context.Pairs select c).ToList();
            pairs.Insert(0, new Pair
            {
                Currencies = "Select a pair",


            });
            ViewBag.Pair = pairs;


            var analysis = _analysisService.GetAnalysis(id);
            ViewBag.id = id;

            var editForms = new EditFormsViewModel()
            {
              StrategyUsed = analysis.StrategyPicked,
              TradingCriteria = analysis.TradingCriteria,
              ExitStrategy = analysis.ExitStrategy,
              TradingTrend = analysis.TradingTrend,
              AcceptanceType = analysis.AcceptanceType,
              RewardRatio = analysis.RewardRatio,
              DescribeTrade = analysis.DescribeTrade,
              PairPicked = analysis.PairPicked,
              MentalState = analysis.MentalState,
              TradeStatus = analysis.TradeStatus,
              TradeOutcome = analysis.TradeOutcome,
              ExplainTrade = analysis.ExplainTrade,
              Note = analysis.Note,
              TimeOfTrade = analysis.TimeOfTrade,
              MetDailyGoal =  analysis.MetDailyGoal,
            };
            return View(editForms);
        }


        [HttpPost]
        public IActionResult EditAnalysis(EditFormsViewModel model)
        {
           
            var analysis = _analysisService.GetAnalysis(model.ID);
            if (ModelState.IsValid)
            {
                analysis.StrategyPicked = model.StrategyPicked;
                analysis.StrategyPicked = model.StrategyPicked;
                analysis.TradingCriteria = model.TradingCriteria;
                analysis.ExitStrategy = model.ExitStrategy;
                analysis.TradingTrend = model.TradingTrend;
                analysis.AcceptanceType = model.AcceptanceType;
                analysis.RewardRatio = model.RewardRatio;
                analysis.DescribeTrade = model.DescribeTrade;
                analysis.PairPicked = model.PairPicked;
                analysis.MentalState = model.MentalState;
                analysis.TradeStatus = model.TradeStatus;
                analysis.TradeOutcome = model.TradeOutcome;
                analysis.MetDailyGoal = model.MetDailyGoal;
                analysis.ExplainTrade = model.ExplainTrade;
                analysis.Note = model.Note;
                analysis.TimeOfTrade = model.TimeOfTrade;

                _analysisStore.Update(analysis);
                return RedirectToAction("index", "analysis");
            }
            return View();
        }

       
        public IActionResult Delete(Guid id)
        {
            var analysis = _analysisService.GetAnalysis(id);
            _analysisStore.Delete(analysis);
           // _analysisStore.GetById(id);
            return RedirectToAction("index","analysis");

        }
    }
}
