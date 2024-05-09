using Lab7.Repositories;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models.DTOs;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpPost]
        public  async Task<IActionResult> AddProductToWarehouse(AddProductWarehouse productWarehouse)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong format");


            if (!await _warehouseRepository.DoesProductExists(productWarehouse.IdProduct) &&
                !await _warehouseRepository.DoesWarehouseExists(productWarehouse.IdWarehouse))
                return NotFound();

            var order = await _warehouseRepository.GetOrderByProductId(productWarehouse.IdProduct);

            if (order.CreatedAt < productWarehouse.CreatedAt)
                return BadRequest("Cannot add order created after createdAt");

            if (order.FulfilledAt != null)
                return BadRequest("The order is already fullfilled");

            await _warehouseRepository.updateOrderFullfilledDate(order.IdOrder);
            

        }
    }
}
