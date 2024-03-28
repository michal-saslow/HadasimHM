using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace HMOBackOffice.Data
{
    public class VaccinationForMemberRepository : IVaccinationForMemberRepository
    {
        private readonly DataContext _context;
        public VaccinationForMemberRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<VaccinationForMember> AddAsync(VaccinationForMember vfm)
        {
            _context.VaccinationForMembers.Add(vfm);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(vfm.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var member = await GetByIdAsync(id);
            _context.VaccinationForMembers.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByMemberIdAsync(int memberId)
        {
            var vfms = await GetAsync(memberId);
            foreach (var vfm in vfms)
            {
                await DeleteAsync(vfm.Id);
            }
        }

        public async Task<List<VaccinationForMember>> GetAsync(int memberId)
        {
            return await _context.VaccinationForMembers.Where(i => i.Member != null && i.Member.Id == memberId).Include(x => x.Member).Include(x => x.Member.City).Include(x => x.Vaccination).ToListAsync();
        }

        public async Task<VaccinationForMember> GetByIdAsync(int id)
        {
            return await _context.VaccinationForMembers.Include(x => x.Vaccination).Include(x => x.Member).FirstAsync(u => u.Id == id);
        }
    }
}
