using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }  // Geliştirilmiş: ProductId küçük harf ile yazılmıştı, bu düzeltildi.
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key
        public Guid CategoryId { get; set; }

        // Navigation property to Category
        public Category Category { get; set; }

        // Navigation property to Offer (Many-to-One relationship with Offer)
        public ICollection<Offer> Offers { get; set; }

        // Navigation property to OrderItem (One-to-Many relationship with OrderItem)
        public ICollection<OrderItem> OrderItems { get; set; }

        // Navigation property to CartItem (One-to-Many relationship with CartItem)
        public ICollection<CartItem> CartItems { get; set; }
    }
}
