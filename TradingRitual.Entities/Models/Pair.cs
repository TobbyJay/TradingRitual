using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class Pair
    {
        public Guid PairId { get; set; }
        public Guid TraderId { get; set; }
        public string Currencies { get; set; }

    }
}
