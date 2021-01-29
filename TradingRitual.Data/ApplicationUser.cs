using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingRitual.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
