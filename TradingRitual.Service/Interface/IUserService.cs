using System;
using System.Collections.Generic;
using System.Text;
using TradingRitual.Entities.Models;

namespace TradingRitual.Service.Interface
{
    public interface IUserService
    {
        public Profile GetUserByEmail(string email);
    }
}
