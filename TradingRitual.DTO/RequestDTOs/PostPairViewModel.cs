using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.DTO.RequestDTOs
{
    public class PostPairViewModel
    {
        //For Pairs
        [Required(ErrorMessage = "This field is required")]
        public string Base { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Quote { get; set; }
    }
}
