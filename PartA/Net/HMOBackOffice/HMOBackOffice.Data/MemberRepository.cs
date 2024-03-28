using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace HMOBackOffice.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;
        private readonly ICityService _cityService;
        private readonly IVaccinationForMemberService _vaccinationForMemberService;
        public MemberRepository(DataContext context, ICityService cityService, IVaccinationForMemberService vaccinationForMemberService)
        {
            _context = context;
            _cityService = cityService;
            _vaccinationForMemberService = vaccinationForMemberService;
        }
        public async Task<Member> AddAsync(Member member, VaccinationForMember[] vfms)
        {
            await _cityService.AddAsync(member.City);
            _context.members.Add(member);
            foreach (var item in vfms)
            {
                item.Member = member;
                item.MemberId = member.Id;
                await _vaccinationForMemberService.AddAsync(item);
            }
            await _context.SaveChangesAsync();
            return await GetByIdAsync(member.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var member = await GetByIdAsync(id);
            _context.members.Remove(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await _context.members.Include(u => u.City).FirstAsync(u => u.Id == id);
        }

        public async Task<List<Member>> GetAsync()
        {
            return await _context.members.Include(u => u.City).ToListAsync();
        }

        public async Task<Member> UpdateAsync(int id, Member member, VaccinationForMember[] vfms)
        {
            var existMember = await GetByIdAsync(id);
            existMember.FirstName = member.FirstName;
            existMember.LastName = member.LastName;
            existMember.Identity = member.Identity;
            existMember.DateOfBirth = member.DateOfBirth;
            existMember.DateOfRecovery = member.DateOfRecovery;
            existMember.DateOfIllness = member.DateOfIllness;
            existMember.CellPhone = member.CellPhone;
            existMember.Phone = member.Phone;
            existMember.ProfileImage = member.ProfileImage;
            await _cityService.UpdateAsync(member.CityId, member.City);
            var existVfms = await _vaccinationForMemberService.GetAsync(id);
            // Adding objects to the database
            foreach (var obj in vfms)
            {
                if (!existVfms.Any(i => i.VaccinationId != null && obj.VaccinationId != null && i.VaccinationId == obj.VaccinationId && i.Date == obj.Date))
                {
                    obj.MemberId = id;
                    await _vaccinationForMemberService.AddAsync(obj);
                }
            }
            //Deleting objects from the database based on vfms array
            foreach (var obj in existVfms)
            {
                if (!vfms.Any(i => i.VaccinationId != null && obj.VaccinationId != null && i.VaccinationId == obj.VaccinationId && i.Date == obj.Date))
                {
                    await _vaccinationForMemberService.DeleteAsync(obj.Id);
                }
            }
            await _context.SaveChangesAsync();
            return existMember;
        }

        public async Task<int> GetNotVaccinatedAsync()
        {
            int count = 0;
            var members = await GetAsync();
            foreach (var member in members)
            {
                var m = await _vaccinationForMemberService.GetAsync(member.Id);
                if (m.Count == 0)
                    count++;
            }
            return count;
        }

        public async Task<IEnumerable<int>> GetPatientsPerDayAsync()
        {
            var members = await _context.members.ToArrayAsync();
            int year = DateTime.Now.Year;
            var mounth = DateTime.Now.Month;
            int[] monimPerDay = new int[DateTime.DaysInMonth(year, mounth)];
            foreach (var m in members)
            {
                if (m.DateOfIllness != null && m.DateOfIllness.Value.Year == year && m.DateOfIllness.Value.Month == mounth)
                {
                    for (var i = m.DateOfIllness; i < m.DateOfRecovery; i = ((DateTime)(i)).AddDays(1))
                    {
                        if (i.Value.Month == mounth)
                            monimPerDay[i.Value.Day]++;
                    }
                }
            }
            return monimPerDay;
        }
    }
}
