using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Data;
using TradingRitual.Entities.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Service.Implementation
{
    public class StrategiesService : IStrategiesService
    {
        private readonly TradingDbContext _context;

        public StrategiesService(TradingDbContext context)
        {
            _context = context;
        }

        public IQueryable<ExitStrategy> GetAllExitStrategy(Guid id)
        {
            var getExitStrategies = _context.ExitStrategies.Where(e => e.TraderId == id).OrderByDescending(o => o.ExitStrategyId);
            return getExitStrategies;
        }

        public IQueryable<Strategy> GetAllStrategy(Guid id)
        {
            var strategies = _context.Strategies.Where(e => e.TraderId == id).OrderByDescending(o => o.StrategyID);
            return strategies;
        }

        public ExitStrategy GetExitStrategy(Guid id)
        {
            var getExitStrategy = _context.ExitStrategies
                .AsNoTracking()
                .FirstOrDefault(ex => ex.ExitStrategyId == id);
            return getExitStrategy;
        }

        public Strategy GetStrategy(Guid id)
        {
            var getStrategy = _context.Strategies
                .AsNoTracking()
                .FirstOrDefault(s => s.StrategyID == id);
            return getStrategy;
        }
    }
}
