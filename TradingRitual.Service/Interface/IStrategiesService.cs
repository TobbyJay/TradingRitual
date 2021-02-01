using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Service.Interface
{
    public interface IStrategiesService
    {
        public IQueryable<Strategy> GetAllStrategy(Guid id);
        public Strategy GetStrategy(Guid id);
        public ExitStrategy GetExitStrategy(Guid id);
        public IQueryable<ExitStrategy> GetAllExitStrategy(Guid id);
    }
}
