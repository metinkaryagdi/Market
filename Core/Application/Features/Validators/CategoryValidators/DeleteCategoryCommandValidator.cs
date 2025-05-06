using Application.Features.Commands.CategoryCommands;
using Application.Features.Queries.CategoryQueries;
using FluentValidation;

namespace Core.Application.Features.Categories.Validators
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category Id must not be empty.");
        }
    }
}
