using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProjectManagementAuth.Definitions
{
    public interface IRepository<T>
        where T : class
    {
        T SelectById(object id);
        IEnumerable<T> SelectAll();
        IEnumerable Find(Predicate<T> expression);
        void Add(T entity);
        void AddRange(IEnumerable entities);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void Save();
    }
}
