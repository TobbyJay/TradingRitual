using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Service.Interface
{
    public interface IAnalysisService
    {
        public IQueryable<Form> GetAllAnalysis(Guid id);

        public Form GetAnalysis(Guid id);
    }
}
