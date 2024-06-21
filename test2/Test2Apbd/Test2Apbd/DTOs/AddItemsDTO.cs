using System.ComponentModel.DataAnnotations;

namespace Test2Apbd.DTOs
{
    public class AddItemsDTO
    {
        public ICollection<AddItemDTO> AddItemsDto { get; set; } = null!;
    }

    public class AddItemDTO
    {
        [Required]
        public int itemId { get; set; }
        public int amount { get; set; }
    }
}
