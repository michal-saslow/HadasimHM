using HMOBackOffice.Core.Entities;
using HMOBackOffice.Core.Repository;
using HMOBackOffice.Core.Service;

namespace HMOBackOffice.Service
{
    public class VaccinationService : IVaccinationService
    {
        private readonly IVaccinationRepository _vaccinationRepository;
        public VaccinationService(IVaccinationRepository vaccinationRepository)
        {
            _vaccinationRepository = vaccinationRepository;
        }

        public async Task<List<Vaccination>> GetAsync()
        {
            return await _vaccinationRepository.GetAsync();
        }

        public async Task<Vaccination> GetByIdAsync(int id)
        {
            return await _vaccinationRepository.GetByIdAsync(id);
        }
    }
}
