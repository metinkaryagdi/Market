using FluentValidation;
using Application.Features.Queries.UserQueries;

namespace Application.Features.Validators.UserValidators
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            // İhtiyaca göre doğrulamalar yapılabilir.
            // Örneğin, belirli bir UserId ile sorgulama yapılıyorsa, UserId'yi doğrulamak
            // için aşağıdaki gibi bir kural eklenebilir.
        }
    }
}
