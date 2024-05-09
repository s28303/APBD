using System.ComponentModel.DataAnnotations;

namespace Tutorial6.Models.DTOs
{
    public class ProductWarehouseDTO
    {
        public int IdProductWarehouse { get; set; }
        public WarehouseDTO Warehouse { get; set; }
        public ProductDTO Product { get; set; }
        public OrderDTO Order { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
