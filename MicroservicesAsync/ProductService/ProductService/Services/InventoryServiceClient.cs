using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductService.Models;
namespace ProductService.Services
{
    public class InventoryServiceClient
    {

        private readonly HttpClient _httpClient;

        public InventoryServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InventoryItem> GetInventoryItemAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7210/api/inventory/{productId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InventoryItem>(content);
        }
    }
}

