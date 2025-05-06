using Application.Features.Commands.UserCommands;
using Core.Application.Interfaces;
using MediatR;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception($"User with ID {request.UserId} not found");
            }

            await _unitOfWork.UserRepository.DeleteAsync(user.UserId);
            await _unitOfWork.CompleteAsync(); // Değişiklikleri kaydet
        }
        catch (Exception ex)
        {
            // Hata fırlat, logla veya daha detaylı bir hata mesajı göster
            throw new Exception("An error occurred while deleting the user", ex);
        }
    }
}
