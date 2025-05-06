using Application.Features.Commands.ProductCommands;
using AutoMapper;
using Core.Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request);
                product.ProductId = Guid.NewGuid(); // ProductId'yi burada set ediyoruz
                product.CreatedAt = DateTime.UtcNow; // CreatedAt'ı burada set ediyoruz

                await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Product creation failed", ex);
            }
        }
    }
}
