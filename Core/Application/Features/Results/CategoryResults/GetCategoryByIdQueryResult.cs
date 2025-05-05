using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
