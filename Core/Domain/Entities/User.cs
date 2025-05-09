﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; } // e.g., Admin, User, etc.
        public DateTime CreatedAt { get; set; }

        // User'ın birden fazla siparişi olabilir
        public ICollection<Order> Orders { get; set; }

        // User'ın birden fazla sepet öğesi olabilir
        public ICollection<CartItem> CartItems { get; set; }
    }

    public enum Role
    {
        Admin,
        Customer,
        Employee
    }
}
