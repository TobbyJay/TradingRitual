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
    public class AnalysisService : IAnalysisService
    {
        private readonly TradingDbContext _context;
        public AnalysisService(TradingDbContext context)
        {
            _context = context;
        }
        public IQueryable<Form> GetAllAnalysis(Guid id)
        {
            var getAnalysis = _context.Forms.Where(a=> a.TraderId == id).OrderByDescending(o => o.FormId);
            return getAnalysis;
        }

        public Form GetAnalysis(Guid id)
        {
           
            var get = _context.Forms.AsNoTracking().FirstOrDefault(a => a.FormId == id);
            return get;
        }
    }
}
