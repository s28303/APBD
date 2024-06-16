using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab10.Models
{
    [Table("prescription_medicament")]
    [PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))] 
    public class PrescriptionMedicament
    {
        
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }

        public int? Dose;
        public string Details { get; set; } = string.Empty;

        [ForeignKey(nameof(IdPrescription))]
        public Prescription Prescription { get; set; } = default!;

        [ForeignKey(nameof(IdMedicament))]
        [MaxLength(100)]
        public Medicament Medicament { get; set; } = default!;
    }
}
