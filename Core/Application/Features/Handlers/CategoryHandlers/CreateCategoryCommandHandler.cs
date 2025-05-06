using Application.Features.Commands.CategoryCommands;
using AutoMapper;
using Core.Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(request);
                category.CategoryId = Guid.NewGuid(); // ID'yi burada ver

                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync(); // UnitOfWork ile değişiklikleri kaydet

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori oluşturulurken hata oluştu.", ex);
            }
        }
    }
}
