using Application.Features.Commands.UserCommands;
using Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository; // IUserRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcıyı repository üzerinden al
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                // Kullanıcı bulunamadıysa hata fırlat
                throw new Exception("User not found");
            }

            // Kullanıcıyı map'le ve güncellenmiş verilerle doldur
            _mapper.Map(request, user);

            // Kullanıcıyı güncelle
            await _userRepository.UpdateAsync(user);

            // Değişiklikleri kaydet
            await _userRepository.SaveChangesAsync();

            return Unit.Value; // MediatR'da void yerine Unit döner
        }
    }
}
