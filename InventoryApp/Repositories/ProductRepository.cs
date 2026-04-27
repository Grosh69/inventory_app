using InventoryApp.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
