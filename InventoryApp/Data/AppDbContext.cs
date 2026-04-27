using Microsoft.EntityFrameworkCore;
using InventoryApp.Models;

namespace InventoryApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories { get; set; }
}