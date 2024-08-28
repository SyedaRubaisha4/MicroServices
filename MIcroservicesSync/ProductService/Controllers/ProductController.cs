using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using Newtonsoft.Json;
namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductWithInventory(int id)
        {
            // Mock data for demonstration
            var product = new Product
            {
                Id = id,
                Name = " Product",
                Price = 19.99m
            };

            // Synchronous call to InventoryService
            var response = _httpClient.GetAsync($"https://localhost:7079/api/inventory/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var inventoryItem = JsonConvert.DeserializeObject<InventoryItem>(content);

                // Combine product and inventory data
                return Ok(new { Product = product, Inventory = inventoryItem });
            }

            return StatusCode((int)response.StatusCode, "Unable to fetch inventory data.");
        }
    }

}
