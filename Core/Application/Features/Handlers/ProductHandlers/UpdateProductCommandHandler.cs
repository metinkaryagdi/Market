using Application.Features.Commands.ProductCommands;
using Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;

namespace Application.Features.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository; // IProductRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Ürünü repository üzerinden al
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                // Ürün bulunamadıysa hata fırlat
                throw new Exception($"Product with ID {request.ProductId} not found");
            }

            // Ürünü map'le ve güncellenmiş verilerle doldur
            _mapper.Map(request, product);

            // Ürünü güncelle
            await _productRepository.UpdateAsync(product);

            // Değişiklikleri kaydet
            await _productRepository.SaveChangesAsync();

            return Unit.Value; // MediatR'da void yerine Unit döner
        }
    }
}
