using InventoryApp.DTOs;
using InventoryApp.Models;
using InventoryApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            await _repository.AddAsync(product);

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            await _repository.DeleteAsync(product);
            return NoContent();
        }
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string name)
        {
            var results = await _repository.SearchByNameAsync(name);
            return Ok(results);
        }
    }
}