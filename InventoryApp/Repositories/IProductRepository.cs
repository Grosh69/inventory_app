using InventoryApp.Models;

namespace InventoryApp.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);
    }
}
