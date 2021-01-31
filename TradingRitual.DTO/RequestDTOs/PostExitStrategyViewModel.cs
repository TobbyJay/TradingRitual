using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.DTO.RequestDTOs
{
    public class PostExitStrategyViewModel
    {
        //For exit strategy
        [Required(ErrorMessage = "This field is required")]
        public string ExitStrategyName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ExitStrategyDescription { get; set; }
       
    }
}
