using Application.Features.Commands.UserCommands;
using MediatR;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly MarketContext _context;
        public DeleteUserCommandHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Users.FindAsync(request.UserId);
            _context.Users.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
