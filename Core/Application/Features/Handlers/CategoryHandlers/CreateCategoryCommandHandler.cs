using Application.Features.Commands.CategoryCommands;
using AutoMapper;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Category>(request);
                category.CategoryId = Guid.NewGuid(); // ID'yi burada ver

                await _categoryRepository.AddAsync(category);
                await _categoryRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori oluşturulurken hata oluştu.", ex);
            }
        }
    }
}
