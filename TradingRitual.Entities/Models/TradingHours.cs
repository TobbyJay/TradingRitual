using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class TradingHours
    {
        public Guid TradingHoursId { get; set; }
        public Guid TraderId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
