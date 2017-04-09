using StudentProjectManagementAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Collections;

namespace StudentProjectManagementAuth.Definitions
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly DbContext _databaseContext = null;
        protected DbSet<T> _table = null;

        public Repository()
        {
            _databaseContext = new ApplicationDbContext();
            _table = _databaseContext.Set<T>();
        }

        public Repository(DbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public void AddRange(IEnumerable entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            var entity = _table.Find(id);
            _table.Remove(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public IEnumerable Find(Predicate<T> expression)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return _table.AsEnumerable();
        }

        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return default(T);
            }
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}