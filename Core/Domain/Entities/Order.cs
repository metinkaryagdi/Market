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

    }
}
public enum Status
{
    Pending,
    Shipped,
    Delivered,
    Cancelled
}