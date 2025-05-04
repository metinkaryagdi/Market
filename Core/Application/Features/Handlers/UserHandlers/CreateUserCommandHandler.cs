using Application.Features.Commands.UserCommands;
using Domain.Entities;
using MediatR;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly MarketContext _context;
        public CreateUserCommandHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(new User
            {
                UserId = Guid.NewGuid(),
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
