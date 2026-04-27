using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InventoryApp.DTOs
{
    public class UpdateProductDto
    {
        public  int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}

