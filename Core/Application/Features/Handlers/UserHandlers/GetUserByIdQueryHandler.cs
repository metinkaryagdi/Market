using Application.Features.Queries.UserQueries;
using Application.Features.Results.UserResults;
using MediatR;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly MarketContext _context;
        public GetUserByIdQueryHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Users.FindAsync( request.UserId);
            return new GetUserByIdQueryResult
            {
                UserId = values.UserId,
                UserName = values.UserName,
                Password = values.Password,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber,
                Address = values.Address,
                DateOfBirth = values.DateOfBirth,
                Role = values.Role,
                CreatedAt = values.CreatedAt
            };
        }
    }
}
