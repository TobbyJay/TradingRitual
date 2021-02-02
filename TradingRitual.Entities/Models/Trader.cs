using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class Trader
    {
        [Key]
        public Guid TraderId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
