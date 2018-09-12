using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentity.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int? id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> criteria);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
