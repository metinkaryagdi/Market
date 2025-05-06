using MediatR;
using System;

namespace Application.Features.Queries.CategoryQueries
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid CategoryId { get; set; }

        public DeleteCategoryCommand(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
