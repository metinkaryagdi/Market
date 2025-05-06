using Application.Features.Queries.ProductQueries;
using FluentValidation;

namespace Application.Features.Validators.ProductValidators
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            // Burada henüz parametre olmadığından validation yok
            // Ancak ileride sayfalama (pagination) gibi parametreler eklersek:
            // RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number must be greater than zero.");
            // RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than zero.");
        }
    }
}
