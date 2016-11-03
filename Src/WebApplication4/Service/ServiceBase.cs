using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication4
{
    public abstract class ServiceBase<TEntity> where TEntity : EntityBase
    {

        public virtual List<TEntity> GetAll()
        {
            using (var accessorDBContext = new MyDBContext())
            {
                return accessorDBContext.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity Get(String id)
        {
            using (var accessorDBContext = new MyDBContext())
            {
                return accessorDBContext.Set<TEntity>().Find(id);
            }
        }

        public virtual Boolean Delete(String id)
        {
            using (var accessorDBContext = new MyDBContext())
            {
                var taskInstance = accessorDBContext.Set<TEntity>().Find(id);
                accessorDBContext.Entry<TEntity>(taskInstance).State = EntityState.Deleted;
                accessorDBContext.SaveChanges();
                return true;
            }
        }

        public virtual Boolean Update(TEntity entity)
        {
            using (var accessorDBContext = new MyDBContext())
            {
                accessorDBContext.Set<TEntity>().Attach(entity);
                accessorDBContext.Entry<TEntity>(entity).State = EntityState.Modified;
                accessorDBContext.SaveChanges();
                return true;
            }
        }

        public virtual Boolean Add(TEntity entity)
        {
            using (var accessorDBContext = new MyDBContext())
            {
                accessorDBContext.Set<TEntity>().Add(entity);
                accessorDBContext.SaveChanges();
                return true;
            }
        }
    }
}
