using Application.Features.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {
        // Opsiyonel: Kategoriye göre filtreleme
        public Guid? CategoryId { get; set; }

    }
}
