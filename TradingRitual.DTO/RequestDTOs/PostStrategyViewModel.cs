using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.DTO.RequestDTOs
{
    public class PostStrategyViewModel
    {
       
        [Required(ErrorMessage = "This field is required")]
        public string SimpleStrategyName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string SimpleStrategyDescription { get; set; }
        public ICollection<string> SimpleStrategyCheckLists { get; set; }

    }
}
