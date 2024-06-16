using lab10.Models;
using Microsoft.EntityFrameworkCore;

namespace lab10.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
            {
                new() {Id = 1, FirstName = "Anton", LastName = "Baton", Email = "antonbaton@gmail.com"}
            });

            modelBuilder.Entity<Patient>().HasData(new List<Patient>()
            {
                new() {Id = 1, FirstName = "Vladyslav", LastName = "Miekh", Birthdate = new DateTime(2003, 1, 20)}
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
            {
                new() {Id = 1, Date = new DateTime(2024, 06, 16), DueDate = new DateTime(2024, 06, 17), IdPatient = 1, IdDoctor = 1}
            });

            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
            {
                new() {Id=1, Name = "Ibuprofen", Description="Ibuprofen is a drug that is used to relieve pain, fever, and inflammation",
                Type="anti-inflammatory"}
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
            {
                new() {IdMedicament = 1, IdPrescription = 1, Dose = 20, Details = "Get better mate"}
            });
        }
    }
}
