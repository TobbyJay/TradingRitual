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
    public class PairController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPairsService _pairService;
        private readonly IDataStore<Pair> _pairStore;
        private readonly IDataStore<Trader> _traderStore;
        private readonly IDataStore<TradingHours> _tradeTimeStore;
        public PairController(IPairsService pairService, SignInManager<ApplicationUser> signInManager, IDataStore<Pair> pairStore, IDataStore<Trader> traderStore)
        {
            _pairService = pairService;
            _signInManager = signInManager;
            _pairStore = pairStore;
            _traderStore = traderStore;
        }


        [HttpGet]
        public ActionResult GetPairs()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            var getPairs = _pairService.GetAllPairs(currentUser.TraderId);
            return Ok(getPairs);

        }


        [HttpGet]
        public IActionResult EditPairs(Guid id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _pairStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(userId));

            var pairs = _pairService.GetPair(id);

            ViewBag.id = id;

            if (pairs == null)
            {

            }
            var editPairs = new PairsViewModel()
            {
                ID = pairs.PairId,
                Currencies = pairs.Currencies,                
                TraderID = currentUser.TraderId
            };
            return View(editPairs);
          
        }

        /// <summary>
        /// This endpoint creates pairs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostPairs(PostEditPageViewModel model)
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var currentUser = _traderStore.GetAll().FirstOrDefault(u => u.TraderId == Guid.Parse(id));

            if (string.IsNullOrWhiteSpace(model.Base))
            {
                return BadRequest(new AuthResponse { Errror = "Error,pairs did not create!" });
            }

            try
            {

                var createPair = new Pair
                {
                    Currencies = $"{model.Base}/{model.Quote}",
                    TraderId = currentUser.TraderId

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

        [HttpPost]
        public ActionResult EditPairs(PairsViewModel model)
        {
            Pair pair = _pairService.GetPair(model.ID);

            pair.Currencies = model.Currencies;         
            _pairStore.Update(pair);
            return Ok(pair);

        }

    }
}
