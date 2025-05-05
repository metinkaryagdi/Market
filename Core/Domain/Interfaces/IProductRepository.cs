using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid ProductId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product Product);
        Task UpdateAsync(Product Product);
        Task DeleteAsync(Guid ProductId);
        Task SaveChangesAsync();
    }
}
