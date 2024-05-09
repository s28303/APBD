namespace Tutorial6.Models.DTOs
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }
        public ProductDTO Product { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FulfilledAt { get; set; }
    }

}

