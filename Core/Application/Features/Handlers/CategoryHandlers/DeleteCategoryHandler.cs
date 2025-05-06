using Application.Features.Commands.CategoryCommands;
using Application.Features.Queries.CategoryQueries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        // Constructor injection ile repo'yu alıyoruz
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Silinecek kategori
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return false; // Kategori bulunamadı
            }

            // Kategoriyi sil
            await _categoryRepository.DeleteAsync(category);
            return true; // Silme işlemi başarılı
        }
    }
}
