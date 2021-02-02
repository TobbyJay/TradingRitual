using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.DTO.ResponseDTOs
{
    public class AnalysisViewModel
    {
        public IQueryable<Form> FormData { get; set; }
    }
}
