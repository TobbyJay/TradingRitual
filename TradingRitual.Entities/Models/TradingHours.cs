using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class TradingHours
    {
        public Guid ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
