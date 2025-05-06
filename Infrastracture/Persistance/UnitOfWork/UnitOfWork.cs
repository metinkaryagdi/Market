using Core.Application.Interfaces;
using Domain.Interfaces;
using Persistance.Context;
using Persistance.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MarketContext _context;

    private Lazy<IProductRepository> _productRepository;
    private Lazy<ICategoryRepository> _categoryRepository;
    private Lazy<IUserRepository> _userRepository;

    public UnitOfWork(MarketContext context)
    {
        _context = context;
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
    }

    public IProductRepository ProductRepository => _productRepository.Value;
    public ICategoryRepository CategoryRepository => _categoryRepository.Value;
    public IUserRepository UserRepository => _userRepository.Value;

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
