using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradingRitual.DTO.RequestDTOs
{
    public class RegisterViewModel
    {
      
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        //[Remote("IsEmailInUse", "Account")]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password do not match")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
