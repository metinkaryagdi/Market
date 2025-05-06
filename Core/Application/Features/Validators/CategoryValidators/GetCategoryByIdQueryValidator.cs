using Application.Features.Queries.CategoryQueries;
using FluentValidation;

namespace Core.Application.Features.Categories.Validators
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category Id must not be empty.");
        }
    }
}
