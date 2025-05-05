using Application.Features.Commands.ProductCommands;
using Application.Features.Commands.UserCommands;
using MediatR;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly MarketContext _context;
        public DeleteProductCommandHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.ProductId);
            _context.Products.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
