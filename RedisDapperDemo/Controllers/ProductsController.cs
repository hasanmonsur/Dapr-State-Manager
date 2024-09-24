using Microsoft.AspNetCore.Mvc;
using RedisDapperDemo.Contacts;
using RedisDapperDemo.Models;
using RedisDapperDemo.Services;

namespace RedisDapperDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ProductsController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var cacheKey = $"product_{id}";
            var product = await _cacheService.GetCacheAsync<Product>(cacheKey);

            if (product != null)
            {
                return Ok(product); // Return from cache
            }

            // Simulate fetching from database (replace with actual DB call)
            product = new Product { Id = id, Name = $"Product {id}", Price = 10.99M };

            // Store in cache
            await _cacheService.SetCacheAsync(cacheKey, product);

            return Ok(product); // Return fresh data
        }
    }
}
