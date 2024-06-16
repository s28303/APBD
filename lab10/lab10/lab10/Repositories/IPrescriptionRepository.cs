using lab10.Models;

namespace lab10.Repositories
{
    public interface IPrescriptionRepository
    {
        Task AddPrescriptionAsync(Prescription prescription);
        Task<bool> MedicamentExistsAsync(int medicamentId);
    }
}
