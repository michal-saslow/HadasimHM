using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Service
{
    public interface IMemberService
    {
        Task<List<Member>> GetAsync();
        Task<int> GetNotVaccinatedAsync();
        Task<IEnumerable<int>> GetPatientsPerDayAsync();
        Task<Member> GetByIdAsync(int id);
        Task<Member> AddAsync(Member member, VaccinationForMember[] vfms);
        Task<Member> UpdateAsync(int id, Member member, VaccinationForMember[] vfms);
        Task DeleteAsync(int id);
    }
}
