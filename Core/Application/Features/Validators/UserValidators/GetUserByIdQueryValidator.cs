using FluentValidation;
using Application.Features.Queries.UserQueries;

namespace Application.Features.Validators.UserValidators
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => id != Guid.Empty).WithMessage("User ID cannot be empty.");
        }
    }
}
