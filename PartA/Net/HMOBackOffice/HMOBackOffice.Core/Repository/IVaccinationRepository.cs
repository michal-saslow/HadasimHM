using HMOBackOffice.Core.Entities;

namespace HMOBackOffice.Core.Repository
{
    public interface IVaccinationRepository
    {
        Task<Vaccination> GetByIdAsync(int id);
        Task<List<Vaccination>> GetAsync();

    }
}
