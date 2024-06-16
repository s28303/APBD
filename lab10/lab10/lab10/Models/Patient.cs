using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab10.Models
{
    [Table("patient")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        public DateTime? Birthdate { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}
