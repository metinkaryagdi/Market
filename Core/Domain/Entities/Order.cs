using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; } // Foreign key to User
        public DateTime OrderDate { get; set; } // Date when the order was placed
        public decimal TotalAmount { get; set; } // Total amount of the order
        public Status Status { get; set; } // e.g., Pending, Shipped, Delivered, Cancelled

        // Navigation property to User
        public User User { get; set; }

        // Navigation property to OrderItem (One-to-Many relationship with OrderItem)
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
public enum Status
{
    Pending,
    Shipped,
    Delivered,
    Cancelled
}