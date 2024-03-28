using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Service
{
    public interface IVaccinationForMemberService
    {
        Task<List<VaccinationForMember>> GetAsync(int memberId);
        Task<VaccinationForMember> GetByIdAsync(int id);
        Task<VaccinationForMember> AddAsync(VaccinationForMember vfm);
        Task DeleteAsync(int id);
        Task DeleteByMemberIdAsync(int memberId);
    }
}
