using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repository
{
    public interface IRepository<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);

    }
}
