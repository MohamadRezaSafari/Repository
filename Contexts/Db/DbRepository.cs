using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core2._2.Models.RepositoryPattern.Interfaces;
using Core3.Data;
using Microsoft.EntityFrameworkCore;

namespace Core2._2.Models.RepositoryPattern.Contexts.Clinic
{
    public class DbRepository<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class where TContext : ApplicationDbContext
    {
        protected TContext _Context { get; set; }
        private DbSet<TEntity> dbSet;

        public DbRepository(TContext Context)
        {
            _Context = Context;
            dbSet = _Context.Set<TEntity>();
        }

        
        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
            //return await _getAll(_Context).ToListAsync();
        }


        public IEnumerable<TEntity> FindAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public Task<TEntity> FindById(object id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<TEntity> FindByNullableId(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("not found");
            }

            var data = await dbSet.FindAsync(id);

            if (data == null)
            {
                throw new ArgumentException("not found");
            }

            return data;
        }


        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> whereCondition)
        {
            return await dbSet.Where(whereCondition).SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _Context.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async void Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("no entity");
            }
            dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("no entity");
            }
            dbSet.Remove(entity);
        }

        public async void CreateRange(IEnumerable<TEntity> entities) => await dbSet.AddRangeAsync(entities);

        public void UpdateRange(IEnumerable<TEntity> entities) => dbSet.UpdateRange(entities);

        public void DeleteRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
