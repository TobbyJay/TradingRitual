using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.DTO.RequestDTOs
{
    public class PostEditPageViewModel
    {
        ////For strategy
        [Required(ErrorMessage = "This field is required")]
        public string SimpleStrategyName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string SimpleStrategyDescription { get; set; }
     //   public ICollection<string> SimpleStrategyCheckLists { get; set; }

        //For exit strategy
        [Required(ErrorMessage = "This field is required")]
        public string ExitStrategyName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ExitStrategyDescription { get; set; }
        //public ICollection<string> ExitStrategyCheckLists { get; set; }

        ////For Pairs 
        [Required(ErrorMessage = "Set your first pair")]
        public string Base { get; set; }
        [Required(ErrorMessage = "Set your second pair")]
        public string Quote { get; set; }

        //For trading hours
        [Required(ErrorMessage = "Set starting time")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Set ending time")]
        public string EndTime { get; set; }


    }
}
