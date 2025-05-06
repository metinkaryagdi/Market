using FluentValidation;
using Application.Features.Commands.UserCommands;

namespace Application.Features.Validators.UserValidators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => id != Guid.Empty).WithMessage("User ID cannot be empty.");
        }
    }
}
