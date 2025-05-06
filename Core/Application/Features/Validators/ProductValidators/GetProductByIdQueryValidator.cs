using Application.Features.Queries.ProductQueries;
using FluentValidation;
using System;

namespace Application.Features.Validators.ProductValidators
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.")
                .Must(BeAValidGuid).WithMessage("Invalid ProductId format.");
        }

        // Guid doğrulaması
        private bool BeAValidGuid(Guid productId)
        {
            return productId != Guid.Empty; // Boş Guid (0000...) geçerli sayılmaz
        }
    }
}
