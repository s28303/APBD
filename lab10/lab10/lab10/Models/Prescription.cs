using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lab10.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        [ForeignKey(nameof(IdPatient))]
        public Patient Patient { get; set; } = default!;

        
        [ForeignKey(nameof(IdDoctor))]
        public Doctor Doctor { get; set; } = default!;

        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new HashSet<PrescriptionMedicament>();

    }
}
