using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private static readonly List<InventoryItem> Inventory = new()
    {
        new InventoryItem { ProductId = 1, Quantity = 100 },
        new InventoryItem { ProductId = 2, Quantity = 200 },
    };

        [HttpGet("{id}")]
        public IActionResult GetInventoryItem(int id)
        {
            var item = Inventory.FirstOrDefault(i => i.ProductId == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }

}
