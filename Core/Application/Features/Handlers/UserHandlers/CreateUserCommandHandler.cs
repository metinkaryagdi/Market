using Application.Features.Commands.UserCommands;
using AutoMapper;
using Core.Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _mapper.Map<User>(request);
            user.UserId = Guid.NewGuid();  // UserId'yi burada set ediyoruz
            user.CreatedAt = DateTime.UtcNow;  // CreatedAt'ı burada set ediyoruz

            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet

            return Unit.Value;
        }
        catch (Exception ex)
        {
            throw new Exception("User creation failed", ex);
        }
    }
}
