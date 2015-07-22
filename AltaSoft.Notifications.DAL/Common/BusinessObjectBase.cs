using AltaSoft.Notifications.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AltaSoft.Notifications.DAL.Common
{
    public abstract class BusinessObjectBase<TEntity> : IDisposable
        where TEntity : ModelBase
    {
        protected MainDbContext db;


        public BusinessObjectBase()
        {
            db = new MainDbContext();
        }


        public virtual int Create(TEntity entity)
        {
            entity.RegDate = DateTime.Now;
            entity.LastUpdateDate = null;

            db.Set<TEntity>().Add(entity);
            db.SaveChanges();

            return entity.Id;
        }

        public virtual void Update(TEntity entity)
        {
            TEntity dbEntity = db.Set<TEntity>().Find(entity.Id);

            entity.LastUpdateDate = DateTime.Now;

            db.Entry<TEntity>(dbEntity).CurrentValues.SetValues(entity);
            db.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            TEntity dbEntity = db.Set<TEntity>().Find(entity.Id);
            db.Set<TEntity>().Remove(dbEntity);
            db.SaveChanges();
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> where)
        {
            int total;
            return GetList(where, 0, int.MaxValue, out total);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> where, int skip, int take, out int total)
        {
            var query = db.Set<TEntity>().Where(where);

            total = query.Count();

            return query.Skip(skip).Take(take).ToList();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
