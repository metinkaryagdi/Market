using Application.Features.Results.ProductResults;
using MediatR;
using System;

namespace Application.Features.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        // Constructor ile ProductId'yi alıyoruz, property için set gerekmiyor.
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }

        // Sadece getter kullanıyoruz, constructor ile gelen değer atandı.
        public Guid ProductId { get; }
    }
}
