using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class Check
    {
        public Guid CheckId { get; set; }
        public Guid StrategyId { get; set; }

        public Guid ExitStrategyId { get; set; }

        public Guid TraderId { get; set; }
    
        public string Checks { get; set; }

    }
}
