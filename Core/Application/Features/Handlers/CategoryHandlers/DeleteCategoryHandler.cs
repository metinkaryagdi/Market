using Application.Features.Commands.CategoryCommands;
using Application.Features.Queries.CategoryQueries;
using Core.Application.Interfaces;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
            {
                return false; // Kategori bulunamadı
            }

            await _unitOfWork.CategoryRepository.DeleteAsync(category.CategoryId);
            await _unitOfWork.CompleteAsync(); // UnitOfWork ile değişiklikleri kaydet
            return true; // Silme işlemi başarılı
        }
    }
}
