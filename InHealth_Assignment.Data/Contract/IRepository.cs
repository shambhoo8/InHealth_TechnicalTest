using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InHealth_Assignment.Data.Contract
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Update(T entity, bool isDeleted = false);
        void Delete(T entity);
        void DeleteById(int[] ids);
        bool DeleteById(int id);
    }
}
