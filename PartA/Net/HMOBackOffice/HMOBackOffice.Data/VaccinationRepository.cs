using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMOBackOffice.Data
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly DataContext _context;
        public VaccinationRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Vaccination> GetByIdAsync(int id)
        {
            return await _context.Vaccinations.FirstAsync(x => x.Id == id);
        }
        public async Task<List<Vaccination>> GetAsync()
        {
            return await _context.Vaccinations.ToListAsync();
        }
    }
}
