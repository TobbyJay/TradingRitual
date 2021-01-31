using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class Check
    {
        public Guid CheckID { get; set; }
        public Guid StrategyID { get; set; }
        public string Checks { get; set; }

    }
}
