using Tutorial6.Models.DTOs;

namespace Lab7.Repositories
{
    public interface IWarehouseRepository
    {
        Task<bool> DoesProductExists(int id);
        Task<bool> DoesWarehouseExists(int id);
        Task<OrderDTO> GetOrderByProductId(int id);
        Task<bool> updateOrderFullfilledDate(int id);
        Task insertProductWarehouse(AddProductWarehouse productWarehouse);
    }
}
