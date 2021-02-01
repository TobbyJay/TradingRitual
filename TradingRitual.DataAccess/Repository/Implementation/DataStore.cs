using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingRitual.Data;

namespace TradingRitual.DataAccess.Repository.Implementation
{
    public class DataStore<T> : IDataStore<T> where T : class
    {
        private readonly TradingDbContext _context;
        public DbSet<T> _entities;
        public DataStore(TradingDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

        //public void Delete(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(Guid id)
        {
            var entity =  GetById(id);
            _entities.Remove(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(Guid id)
        {
            return _entities.Find(id);
        }

        public T Post(T entity)
        {
            if (_entities == null) throw new ArgumentNullException();
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

       
        public void Update(T entity)
        {
            if (_entities == null) throw new ArgumentNullException();
            _entities.Update(entity);
            _context.SaveChanges();
        }

        T IDataStore<T>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }



        //public Owner GetOwnerByEmail(string email)
        //{
        //    return _context.Owners.FirstOrDefault(ownerHub => ownerHub.Email == email);

        //}
    }
}
