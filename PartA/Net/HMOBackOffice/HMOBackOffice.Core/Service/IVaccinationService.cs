using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Service
{
    public interface IVaccinationService
    {
        Task<Vaccination> GetByIdAsync(int id);
        Task<List<Vaccination>> GetAsync();
    }
}
