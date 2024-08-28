using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly InventoryServiceClient _inventoryServiceClient;

        public ProductController(InventoryServiceClient inventoryServiceClient)
        {
            _inventoryServiceClient = inventoryServiceClient;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductWithInventory(int id)
        {
            var product = new Product { Id = id, Name = $"Product{id}" };
            var inventoryItem = await _inventoryServiceClient.GetInventoryItemAsync(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            var result = new
            {
                Product = product,
                Inventory = inventoryItem
            };

            return Ok(result);
        }
    }

}
