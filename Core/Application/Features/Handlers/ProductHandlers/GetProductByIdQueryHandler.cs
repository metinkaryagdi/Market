using Application.Features.Queries.ProductQueries;
using Application.Features.Results.ProductResults;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _productRepository; // IProductRepository'i kullanıyoruz
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // ProductId ile ürünü repository üzerinden al
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // AutoMapper ile Entity'yi DTO'ya dönüştür
            var result = _mapper.Map<GetProductByIdQueryResult>(product);

            return result;
        }
    }
}
