using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; } // Quantity of the product in the cart
        public decimal Price { get; set; } // Price of the product at the time of adding to cart
        public DateTime AddedAt { get; set; } // Date when the item was added to the cart
        public Guid UserId { get; set; } // Foreign key to User

        // Navigation property to Product
        public Product Product { get; set; }

        // Navigation property to User
        public User User { get; set; }
    }

}
