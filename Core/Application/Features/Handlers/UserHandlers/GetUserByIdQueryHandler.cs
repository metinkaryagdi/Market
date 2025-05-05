using Application.Features.Results.UserResults;
using Application.Features.Queries.UserQueries;
using AutoMapper;
using Domain.Interfaces; // IUserRepository'i kullanıyoruz
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository _userRepository; // IUserRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // UserId ile kullanıcıyı repository üzerinden al
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // AutoMapper ile Entity'yi DTO'ya dönüştür
            var result = _mapper.Map<GetUserByIdQueryResult>(user);

            return result;
        }
    }
}
