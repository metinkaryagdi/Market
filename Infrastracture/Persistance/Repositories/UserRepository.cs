using Domain.Entities;
using Domain.Interfaces;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketContext _context;

        public UserRepository(MarketContext context)
        {
            _context = context;
        }

        // UserId'ye göre kullanıcıyı al
        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId); // Kullanıcıyı UserId'ye göre sorgular
        }

        // Tüm kullanıcıları al
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync(); // Tüm kullanıcıları listele
        }

        // Yeni kullanıcı ekle
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user); // Kullanıcıyı veritabanına ekler
        }

        // Kullanıcıyı güncelle
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user); // Kullanıcıyı günceller
        }

        // Kullanıcıyı sil
        public async Task DeleteAsync(Guid userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId); // Kullanıcıyı UserId'ye göre bul
            if (user != null)
            {
                _context.Users.Remove(user); // Kullanıcıyı sil
            }
        }

        // Değişiklikleri kaydet
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); // Yapılan değişiklikleri veritabanına kaydeder
        }

        // Kullanıcıyı ekle (AddAsync ile aynı işlevde)
        public async Task AddUserAsync(User user)
        {
            await AddAsync(user); // Kullanıcıyı ekler
        }

        // Değişiklikleri kaydet (SaveAsync ile aynı işlevde)
        public async Task SaveChangesAsync()
        {
            await SaveAsync(); // Kaydetme işlemi
        }
    }
}
