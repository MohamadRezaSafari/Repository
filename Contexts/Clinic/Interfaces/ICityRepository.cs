using System.Collections.Generic;
using Core2._2.Models.RepositoryPattern.Interfaces;
using Core3.Models;

namespace Core2._2.Models.RepositoryPattern.Contexts.Clinic.Interfaces
{
    public interface ICityRepository : IRepositoryBase<Cities>
    {
       IEnumerable<Cities> GetAllCitieses();
    }
}
