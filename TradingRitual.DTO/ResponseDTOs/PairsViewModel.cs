using System;
using System.Collections.Generic;
using System.Text;
using TradingRitual.DTO.RequestDTOs;

namespace TradingRitual.DTO.ResponseDTOs
{
    public class PairsViewModel : PostEditPageViewModel
    {
        public Guid ID { get; set; }
        public string Currencies { get; set; }


    }
}
