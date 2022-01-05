using DataAccessLayer.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        FeedMeContext feedMeContext = new FeedMeContext();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = feedMeContext.Set<T>();
        }
        public void Delete(T t)
        {
            var deletedEntity = feedMeContext.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(t);
            feedMeContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = feedMeContext.Entry(t);//entry = giriş
            addedEntity.State = EntityState.Added;
            // _object.Add(t);
            feedMeContext.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = feedMeContext.Entry(t);
            updatedEntity.State = EntityState.Modified;
            feedMeContext.SaveChanges();
        }
    }
}
