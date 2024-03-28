using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMOBackOffice.Data
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<City> AddAsync(City city)
        {
            _context.Citys.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Citys.FirstAsync(u => u.Id == id);
        }

        public async Task<City> UpdateAsync(int id, City city)
        {
            var existCity = await GetByIdAsync(id);
            existCity.HouseNumber = city.HouseNumber;
            existCity.Address = city.Address;
            existCity.Name = city.Name;
            await _context.SaveChangesAsync();
            return existCity;
        }

    }
}
