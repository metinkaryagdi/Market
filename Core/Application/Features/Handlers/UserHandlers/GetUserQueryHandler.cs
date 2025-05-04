using Application.Features.Queries.UserQueries;
using Application.Features.Results.UserResults;
using MediatR;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly MarketContext _context;
        public GetUserQueryHandler(MarketContext context)
        {
            _context = context;
        }
        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Users.ToListAsync();
            return values.Select(x => new GetUserQueryResult
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Role = x.Role,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
    }
}
