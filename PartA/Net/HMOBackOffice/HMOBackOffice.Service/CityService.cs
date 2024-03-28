using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;

namespace HMOBackOffice.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<City> AddAsync(City city)
        {
            return await _cityRepository.AddAsync(city);
        }
        public async Task<City> GetByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<City> UpdateAsync(int id, City city)
        {
            return await _cityRepository.UpdateAsync(id, city);
        }
    }
}
