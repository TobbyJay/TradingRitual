
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingRitual.DataAccess.Repository.Implementation
{
   public interface IDataStore<T> where T : class
    {
         IQueryable<T> GetAll();
         T GetById(Guid id);
        void Update(T entity);
         T Post(T entity);
        void Delete(T entity);

        T Delete(Guid id);




    }
}
