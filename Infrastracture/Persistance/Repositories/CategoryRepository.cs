using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext _context;

        public CategoryRepository(MarketContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Category category)
        {
            if (category != null)
            {
                _context.Categories.Remove(category);
                return Task.CompletedTask;
            }
            else
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
        }
    }
}
