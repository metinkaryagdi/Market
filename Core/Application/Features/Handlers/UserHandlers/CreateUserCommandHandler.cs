using Application.Features.Commands.UserCommands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Persistance.Context;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository; // UserRepository bağımlılığı
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // AutoMapper ile CreateUserCommand'dan User entity'sine dönüşüm
            var user = _mapper.Map<User>(request);
            user.UserId = Guid.NewGuid();               // UserId'yi burada set ediyoruz
            user.CreatedAt = DateTime.UtcNow;           // CreatedAt'ı burada set ediyoruz

            // Repository üzerinden kullanıcıyı ekliyoruz
            await _userRepository.AddUserAsync(user);

            // Veritabanına kaydediyoruz
            await _userRepository.SaveChangesAsync();

            return Unit.Value; // MediatR'da void yerine bu döner
        }
        catch (Exception ex)
        {
            // Hata oluştuğunda özel bir hata mesajı dönebiliriz
            throw new Exception("User creation failed", ex);
        }
    }
}
