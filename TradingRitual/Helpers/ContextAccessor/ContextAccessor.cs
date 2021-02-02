using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;
using TradingRitual.DataAccess.Repository.Implementation;
using TradingRitual.Entities.Models;

namespace TradingRitual.Helpers.ContextAccessor
{
    public class ContextAccessor : IContextAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDataStore<Trader> _traderStore;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ContextAccessor(IHttpContextAccessor contextAccessor, SignInManager<ApplicationUser> signInManager, IDataStore<Trader> traderStore)
        {
            _contextAccessor = contextAccessor;
            _signInManager = signInManager;
            _traderStore = traderStore;
        }
        public Guid GetTraderId()
        {
            //var identity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            //// Gets list of claims.
            //var claim = identity.Claims;

            //// Gets traderId from claims.
            //var traderIdClaim = claim.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            ////convert to Guid
            //return Guid.Parse(traderIdClaim);

          


            var test = "";
            return Guid.Parse(test);
        }
    }
}
