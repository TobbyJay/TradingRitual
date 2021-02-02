using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Service.Interface
{
    public interface IPairsService
    {
        public IQueryable<Pair> GetAllPairs(Guid id);
        public IQueryable<Pair> GetPairs(Guid id);
        public Pair GetPair(Guid id);
    }
}
