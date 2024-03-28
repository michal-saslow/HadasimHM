using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;

namespace HMOBackOffice.Service
{
    public class VaccinationForMemberService : IVaccinationForMemberService
    {
        private readonly IVaccinationForMemberRepository _vaccinationForMemberRepository;
        private readonly IVaccinationService _vaccinationService;
        public VaccinationForMemberService(IVaccinationForMemberRepository vaccinationForMemberRepository, /*IMemberService memberService*//*, */IVaccinationService vaccinationService)
        {
            _vaccinationForMemberRepository = vaccinationForMemberRepository;
            _vaccinationService = vaccinationService;
        }
        public async Task<VaccinationForMember> AddAsync(VaccinationForMember vfm)
        {
            if (await IsValid(vfm))
            {
                return await _vaccinationForMemberRepository.AddAsync(vfm);
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            await _vaccinationForMemberRepository.DeleteAsync(id);
        }

        public async Task DeleteByMemberIdAsync(int memberId)
        {
            await _vaccinationForMemberRepository.DeleteByMemberIdAsync(memberId);
        }

        public async Task<List<VaccinationForMember>> GetAsync(int memberId)
        {
            return await _vaccinationForMemberRepository.GetAsync(memberId);
        }

        public async Task<VaccinationForMember> GetByIdAsync(int id)
        {
            return await _vaccinationForMemberRepository.GetByIdAsync(id);
        }
        private async Task<bool> IsValid(VaccinationForMember vfm)
        {
            if (vfm.Vaccination is not null)
            {
                var vaccination = await _vaccinationService.GetByIdAsync(vfm.Vaccination.Id);
                if (vaccination is null)
                {
                    return false;
                }
            }
            if (vfm.Date is not null && vfm.Date > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
