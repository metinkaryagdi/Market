using Application.Features.Results.ProductResults;
using Application.Features.Queries.ProductQueries;
using AutoMapper;
using Domain.Interfaces; // IProductRepository'i kullanıyoruz
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IProductRepository _productRepository; // IProductRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            // Ürünleri repository üzerinden al
            var products = await _productRepository.GetAllAsync();

            // AutoMapper ile Entity'leri DTO'ya dönüştür
            var result = _mapper.Map<List<GetProductQueryResult>>(products);

            return result;
        }
    }
}
