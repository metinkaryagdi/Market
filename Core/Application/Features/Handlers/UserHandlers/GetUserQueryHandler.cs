using Application.Features.Results.UserResults;
using Application.Features.Queries.UserQueries;
using AutoMapper;
using Domain.Interfaces; // IUserRepository'i kullanıyoruz
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IUserRepository _userRepository; // IUserRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcıları repository üzerinden al
            var users = await _userRepository.GetAllAsync();

            // AutoMapper ile Entity'leri DTO'ya dönüştür
            var result = _mapper.Map<List<GetUserQueryResult>>(users);

            return result;
        }
    }
}
