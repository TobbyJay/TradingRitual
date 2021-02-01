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
    public class PairsService : IPairsService
    {
        private readonly TradingDbContext _context;

        public PairsService(TradingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Pair> GetAllPairs(Guid id)
        {
            var getPairs = _context.Pairs.Where(p => p.TraderId == id).OrderByDescending(o=> o.PairId);
            return getPairs;
        }
        public IQueryable<Pair> GetPairs(Guid id)
        {
            var getPairs = _context.Pairs.Where(p => p.TraderId == id);
            return getPairs;
        }

       

        public Pair GetPair(Guid id)
        {
            var getPair = _context.Pairs.AsNoTracking().FirstOrDefault(p => p.PairId == id);
            return getPair;
        }
    }
}
