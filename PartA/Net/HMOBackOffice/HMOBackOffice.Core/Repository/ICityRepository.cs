using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Repository
{
    public interface ICityRepository
    {
        Task<City> GetByIdAsync(int id);
        Task<City> AddAsync(City city);
        Task<City> UpdateAsync(int id, City city);
    }
}
