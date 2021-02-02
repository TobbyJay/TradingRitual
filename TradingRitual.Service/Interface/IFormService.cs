using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Service.Interface
{
    public interface IFormService
    {
        public IQueryable<Form> GetWins(Guid id);
        public IQueryable<Form> GetLosses(Guid id);
        public List<Form> GetAnalysisForDashboard (Guid id, int page);
    }
}
