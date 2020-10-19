using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core2._2.Models.RepositoryPattern.Contexts.Clinic.Interfaces;
using Core2._2.Models.RepositoryPattern.Interfaces;
using Core3.Models;

namespace Core2._2.Models.RepositoryPattern.Contexts.Clinic.Repository
{
    public class CityRepository : IRepositoryBase<Cities>, ICityRepository
    {
        private readonly ClinicContext _context;
        private readonly IUnitOfWork _uw;
        private ClinicContext context;


        public CityRepository(ClinicContext context)
        {
            this.context = context;
        }

        public void Create(Cities entity)
        {
            _uw.ClinicRepository<Cities>().Create(entity);
            _uw.Commit();
        }

        public void CreateRange(IEnumerable<Cities> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cities entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Cities> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cities> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cities>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cities>> FindByConditionAsync(Expression<Func<Cities, bool>> filter = null, Func<IQueryable<Cities>, IOrderedQueryable<Cities>> orderBy = null, params Expression<Func<Cities, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<Cities> FindById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Cities> FindByNullableId(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cities> GetAllCitieses()
        {
            return _uw.ClinicRepository<Cities>().FindAll();
        }

        public Task<Cities> SingleOrDefaultAsync(Expression<Func<Cities, bool>> whereCondition)
        {
            throw new NotImplementedException();
        }

        public void Update(Cities entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Cities> entities)
        {
            throw new NotImplementedException();
        }
    }
}
