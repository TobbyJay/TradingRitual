using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingRitual.Helpers.ContextAccessor
{
    public interface IContextAccessor
    {

        Guid GetTraderId();
    }
}
