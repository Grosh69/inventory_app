using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _repository.GetAllAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _repository.AddAsync(product);
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> Search(string name)
        {
            var products = await _repository.SearchByNameAsync(name);
            var resultsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(resultsDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateDto)
        {
            if (id != updateDto.Id) return BadRequest("ID mismatch");

            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();

            _mapper.Map(updateDto, product);

            await _repository.UpdateAsync(product);

            return NoContent();
        }
        /* [HttpGet("throw-error")]
         public IActionResult ThrowError()
         {
             // Szándékosan dobunk egy általános hibát
             throw new Exception("Ez egy teszt hiba a Middleware teszteléséhez!");
         } */
    }
}