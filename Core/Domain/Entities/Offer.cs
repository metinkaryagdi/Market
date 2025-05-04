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
        public string OfferName { get; set; } // Name of the offer
        public decimal DiscountPercentage { get; set; } // Discount percentage for the offer
        public DateTime StartDate { get; set; } // Start date of the offer
        public DateTime EndDate { get; set; } // End date of the offer
        public string Description { get; set; } // Description of the offer
        public bool IsActive { get; set; } // Indicates if the offer is currently active
        public Guid ProductId { get; set; } // Foreign key to Product
    }
}
