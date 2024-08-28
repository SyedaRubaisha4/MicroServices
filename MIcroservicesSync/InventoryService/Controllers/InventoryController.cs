using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<InventoryItem> GetInventoryItem(int id)
        {
            // Mock data for demonstration
            var inventoryItem = new InventoryItem
            {
                Id = id,
                Name = "Item",
                Quantity = 100
            };

            return Ok(inventoryItem);
        }
    }

}
