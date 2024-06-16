using lab10.Models;

namespace lab10.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient?> GetPatientAsync(int id);
        Task AddPatientAsync(Patient patient);
    }
}
