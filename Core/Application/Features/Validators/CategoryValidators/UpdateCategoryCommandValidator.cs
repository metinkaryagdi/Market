using Application.Features.Commands.CategoryCommands;
using FluentValidation;

namespace Core.Application.Features.Categories.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category Id must not be empty.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name is required.")
                .Length(2, 50).WithMessage("Category Name must be between 2 and 50 characters.");
        }
    }
}
