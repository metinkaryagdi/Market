using MediatR;
using Application.Features.Results.CategoryResults;  // Bu importu eklemeyi unutma

namespace Application.Features.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>  // Burada GetCategoryByIdQueryResult döndürülecek
    {
        public GetCategoryByIdQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; set; }
    }
}
