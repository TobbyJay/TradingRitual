using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Data;
using TradingRitual.Entities.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly TradingDbContext _context;
        public UserService(TradingDbContext context)
        {
            _context = context;
        }
        public Trader GetUserByEmail(string email)
        {
            var getUserName = _context.Traders
                  .AsNoTracking()
                 .FirstOrDefault(p => p.Email == email);

            return getUserName;
        }
    }
}
