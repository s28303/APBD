
using Microsoft.Data.SqlClient;
using Tutorial6.Models.DTOs;

namespace Lab7.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IConfiguration _configuration;
        public WarehouseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> DoesProductExists(int id)
        {
            var query = "SELECT 1 FROM Product WHERE IdProduct = @ID";

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();

            var res = await command.ExecuteScalarAsync();

            return res is not null;
        }

        public async Task<bool> DoesWarehouseExists(int id)
        {
            var query = "SELECT 1 FROM Warehouse WHERE IdWarehouse = @ID";

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();

            var res = await command.ExecuteScalarAsync();

            return res is not null;
        }

        public async Task<OrderDTO> GetOrderByProductId(int id)
        {
            var query = @"SELECT o.IdOrder, o.IdProduct, o.Amount, o.CreatedAt, o.FulfilledAt, 
                         p.Name AS ProductName, p.Description AS ProductDescription, p.Price AS ProductPrice
                        FROM Order o
                        JOIN Product p ON o.IdProduct = p.IdProduct
                        WHERE p.IdProduct = @ID;";

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();

            if (!reader.HasRows)
                throw new Exception("Order not found");

            var idOrderOrdinal = reader.GetOrdinal("IdOrder");
            var idProductOrdinal = reader.GetOrdinal("IdProduct");
            var amountOrdinal = reader.GetOrdinal("Amount");
            var createdAtOrdinal = reader.GetOrdinal("CreatedAt");
            var fulfilledAtOrdinal = reader.GetOrdinal("FulfilledAt");
            var productNameOrdinal = reader.GetOrdinal("ProductName");
            var productDescriptionOrdinal = reader.GetOrdinal("ProductDescription");
            var productPriceOrdinal = reader.GetOrdinal("ProductPrice");

            var orderDTO = new OrderDTO
            {
                IdOrder = reader.GetInt32(idOrderOrdinal),
                Amount = reader.GetInt32(amountOrdinal),
                CreatedAt = reader.GetDateTime(createdAtOrdinal),
                FulfilledAt = reader.GetDateTime(fulfilledAtOrdinal),
                Product = new ProductDTO
                {
                    Name = reader.GetString(productNameOrdinal),
                    Description = reader.GetString(productDescriptionOrdinal),
                    Price = reader.GetDecimal(productPriceOrdinal)
                }
            };

            return orderDTO;
        }

        public async Task updateOrderFullfilledDate(int id)
        {
            var query = @"UPDATE Order
                  SET FulfilledAt = @FulfilledAt
                  WHERE IdOrder = @OrderId";

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = query;

            command.Parameters.AddWithValue("@FulfilledAt", DateTime.UtcNow);
            command.Parameters.AddWithValue("@OrderId", id);

            await connection.OpenAsync();

            int rowsAffected = await command.ExecuteNonQueryAsync();

            if (rowsAffected == 0)
                throw new Exception($"Order not found");
            
        }
    }
}
