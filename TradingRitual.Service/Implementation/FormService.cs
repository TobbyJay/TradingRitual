using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingRitual.Data;
using TradingRitual.Entities.Models;
using TradingRitual.Service.Interface;

namespace TradingRitual.Service.Implementation
{
    public class FormService : IFormService
    {
        private readonly TradingDbContext _context;

        public FormService(TradingDbContext context)
        {
            _context = context;
        }

        public List<Form> GetAnalysisForDashboard(Guid id, int page)
        {

            var getLosses = _context.Forms.Where(p => p.TraderId == id).OrderByDescending(o => o.FormId).Skip((page - 1) *5).Take(5).ToList();
            return getLosses;
        }


        public IQueryable<Form> GetWins(Guid id)
        {
            var getWins = _context.Forms.Where(p => p.TraderId == id || p.TradeOutcome == "Win");
            return getWins;
        }
    }
}
