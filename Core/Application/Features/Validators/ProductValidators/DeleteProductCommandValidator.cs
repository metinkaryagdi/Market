using Application.Features.Commands.ProductCommands;
using Application.Features.Commands.UserCommands;
using FluentValidation;

namespace Core.Application.Features.Products.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty).WithMessage("ProductId is required.");
        }
    }
}
