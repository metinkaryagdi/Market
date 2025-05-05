using Application.Features.Commands.CategoryCommands;
using Domain.Entities;
using MediatR;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly MarketContext _context;
        public CreateCategoryCommandHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _context.Categories.AddAsync(new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = request.CategoryName

            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
