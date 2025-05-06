using Application.Features.Commands.CategoryCommands;
using FluentValidation;

namespace Core.Application.Features.Categories.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name is required.")
                .Length(2, 50).WithMessage("Category Name must be between 2 and 50 characters.");
        }
    }
}
