using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Category'nin sahip olduğu ürünleri temsil eder (Navigation property)
        public ICollection<Product> Products { get; set; }
    }

}
