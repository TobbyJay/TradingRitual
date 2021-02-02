using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.DTO.ResponseDTOs
{
    public class DashboardViewModel
    {
        public IQueryable<Pair> Pairs { get; set; }
        public List<Form> AnalysisDetails { get; set; }
        public IQueryable<Form> TradeWins { get; set; }
        public IQueryable<FormsViewModel> FormDetails { get; set; }
        public TradingHours TradingHours { get; set; }


    }
}
