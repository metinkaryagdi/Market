using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repository'ler burada yer alacak
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }

        // SaveChanges metodu
        Task<int> CompleteAsync();
    }
}
