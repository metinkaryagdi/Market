using Application.Features.Commands.ProductCommands;
using Application.Features.Commands.UserCommands;
using Core.Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            await _unitOfWork.ProductRepository.DeleteAsync(product.ProductId);
            await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet
        }
    }
}
