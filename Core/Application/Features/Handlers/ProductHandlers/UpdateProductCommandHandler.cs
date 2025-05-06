using Application.Features.Commands.ProductCommands;
using Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Core.Application.Interfaces;

namespace Application.Features.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception($"Product with ID {request.ProductId} not found");
            }

            _mapper.Map(request, product);

            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet

            return Unit.Value;
        }
    }
}
