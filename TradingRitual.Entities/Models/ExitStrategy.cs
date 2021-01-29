﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TradingRitual.Entities.Models
{
    public class ExitStrategy
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public List<string> ExitCheckList { get; set; }
    }
}
