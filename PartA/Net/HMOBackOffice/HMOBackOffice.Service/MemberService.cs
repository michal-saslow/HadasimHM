using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;

namespace HMOBackOffice.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> AddAsync(Member member, VaccinationForMember[] vfms)
        {
            if (IsValid(member))
            {
                return await _memberRepository.AddAsync(member, vfms);
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            await _memberRepository.DeleteAsync(id);
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<List<Member>> GetAsync()
        {
            return await _memberRepository.GetAsync();
        }

        public async Task<Member> UpdateAsync(int id, Member member, VaccinationForMember[] vfms)
        {
            if (IsValid(member))
            {
                return await _memberRepository.UpdateAsync(id, member, vfms);
            }
            return null;
        }

        public async Task<int> GetNotVaccinatedAsync()
        {
            return await _memberRepository.GetNotVaccinatedAsync();
        }

        public async Task<IEnumerable<int>> GetPatientsPerDayAsync()
        {
            return await _memberRepository.GetPatientsPerDayAsync();
        }
        private bool IsValid(Member member)
        {
            if (member.DateOfRecovery != null && member.DateOfIllness == null)
            {
                return false;
            }
            if (member.DateOfRecovery != null && member.DateOfRecovery > DateTime.Now)
            {
                return false;
            }
            if (member.DateOfIllness != null && member.DateOfIllness > DateTime.Now)
            {
                return false;
            }
            if (member.DateOfRecovery != null && member.DateOfIllness != null && member.DateOfRecovery < member.DateOfIllness)
            {
                return false;
            }
            if (member.Identity != null && member.Identity.Length != 9)
            {
                return false;
            }
            if (member.DateOfBirth != null && member.DateOfBirth > DateTime.Now)
            {
                return false;
            }
            if (member.Phone != null && member.Phone.Length != 9 && member.Phone.Length != 10)
            {
                return false;
            }
            if (member.CellPhone != null && member.CellPhone.Length != 10)
            {
                return false;
            }
            if (member.Phone != null && member.Phone.ElementAt(0) != '0')
            {
                return false;
            }
            if (member.CellPhone != null && !member.CellPhone.StartsWith("05"))
            {
                return false;
            }
            return true;
        }
    }
}
