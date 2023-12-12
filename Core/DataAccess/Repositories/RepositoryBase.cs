using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity> 
        where TContext: DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }

        public RepositoryBase(TContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return Context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter=null)
        {
            return filter == null
                    ? Context.Set<TEntity>().ToList()
                    : Context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = Context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
