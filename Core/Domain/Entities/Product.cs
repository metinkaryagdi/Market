using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } // URL to the product image
        public DateTime CreatedAt { get; set; } // Date when the product was added
        public Guid CategoryId { get; set; } // Foreign key to Category
    }
}
