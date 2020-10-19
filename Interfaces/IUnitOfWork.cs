using System;
using System.Threading.Tasks;
using Core3.Data;
using Core3.Models;

namespace Core2._2.Models.RepositoryPattern.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ClinicContext _Context { get; }
        IRepositoryBase<TEntity> ClinicRepository<TEntity>() where TEntity : class;
        ApplicationDbContext _ApplicationDbContext { get; }
        IRepositoryBase<TEntity> DbRepository<TEntity>() where TEntity : class;
        Task Commit();
    }
}
