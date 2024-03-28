using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Service
{
    public interface ICityService
    {
        Task<City> GetByIdAsync(int id);
        Task<City> AddAsync(City city);
        Task<City> UpdateAsync(int id, City city);
    }
}
