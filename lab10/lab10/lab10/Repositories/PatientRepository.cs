using lab10.Data;
using lab10.Models;
using Microsoft.EntityFrameworkCore;

namespace lab10.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationContext _context; 
        public PatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task AddPatientAsync(Patient patient)
        {
            throw new NotImplementedException();
        }

        public async Task<Patient?> GetPatientAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Prescriptions)
                .ThenInclude(p => p.PrescriptionMedicaments)
                //.ThenInclude(pm => pm.Medicament)
                //.Include(p => p.Prescriptions)
                //    .ThenInclude(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
