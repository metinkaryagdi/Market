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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly MarketContext _context;
        public UpdateUserCommandHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Users.FindAsync(request.UserId);
                values.UserName = request.UserName;
                values.Password = request.Password;
                values.Email = request.Email;
                values.PhoneNumber = request.PhoneNumber;
                values.Address = request.Address;
                values.DateOfBirth = request.DateOfBirth;
                values.Role = request.Role;
                await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
