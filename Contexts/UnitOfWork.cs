using System;
using System.Threading.Tasks;
using Core2._2.Models.RepositoryPattern.Contexts.Clinic;
using Core2._2.Models.RepositoryPattern.Interfaces;
using Core3.Data;
using Core3.Models;

namespace Core2._2.Models.RepositoryPattern.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        public ClinicContext _Context { get; }
        public ApplicationDbContext _ApplicationDbContext { get; }


        public UnitOfWork(ClinicContext context, ApplicationDbContext applicationDbContext)
        {
            _Context = context;
            _ApplicationDbContext = applicationDbContext;
        }

        public IRepositoryBase<TEntity> ClinicRepository<TEntity>() where TEntity : class
        {
            IRepositoryBase<TEntity> repository = new ClinicRepository<TEntity, ClinicContext>(_Context);
            return repository;
        }

        public IRepositoryBase<TEntity> DbRepository<TEntity>() where TEntity : class
        {
            IRepositoryBase<TEntity> repository = new DbRepository<TEntity, ApplicationDbContext>(_ApplicationDbContext);
            return repository;
        }

        public async Task Commit()
        {
            using (var trs = await _Context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _Context.SaveChangesAsync();
                    trs.Commit();
                }
                catch (Exception e)
                {
                    trs.Rollback();
                    throw;
                }
            }
        }

       
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
            //_Context.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
