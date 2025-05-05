using Application.Features.Commands.ProductCommands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request);
                product.ProductId = Guid.NewGuid(); // ProductId'yi burada set ediyoruz
                product.CreatedAt = DateTime.UtcNow; // CreatedAt'ı burada set ediyoruz

                // Repository üzerinden ürünü ekliyoruz
                await _productRepository.AddAsync(product);

                // Veritabanına kaydediyoruz
                await _productRepository.SaveChangesAsync();

                return Unit.Value; // MediatR'da void yerine bu döner
            }
            catch (Exception ex)
            {
                // Daha spesifik bir hata fırlatmak daha iyi olabilir
                throw new Exception("Product creation failed", ex);
            }
        }
    }
}
