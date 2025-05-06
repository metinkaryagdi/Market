using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Offer
    {
        public Guid OfferId { get; set; }
        public string OfferName { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Foreign key to Product
        public Guid ProductId { get; set; }

        // Navigation property to Product
        public Product Product { get; set; }
    }

}
