using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Results.ProductResults
{
    public class GetProductQueryResult
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public Guid CategoryId { get; set; } 
    }
}
