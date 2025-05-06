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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // IRequestHandler<UpdateCategoryCommand> arayüzüne uygun olarak, Task<Unit> dönüş tipi ile implement ediliyor.
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            // Güncellenmiş kategoriyi AutoMapper ile entity'ye aktarıyoruz.
            _mapper.Map(request, category);

            // Veritabanında güncelleme yapıyoruz.
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return Unit.Value; // MediatR'da void yerine Unit.Value döner.
        }
    }
}
