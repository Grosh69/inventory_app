using Microsoft.AspNetCore.Mvc;
using InventoryApp.Data;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using InventoryApp.DTOs;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]            
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}