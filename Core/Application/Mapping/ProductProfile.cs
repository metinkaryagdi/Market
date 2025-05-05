using Application.Features.Commands.ProductCommands;
using Application.Features.Commands.UserCommands;
using Application.Features.Queries.ProductQueries;
using Application.Features.Results.ProductResults;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, GetProductByIdQueryResult>().ReverseMap();
            CreateMap<Product, GetProductQueryResult>().ReverseMap();
            // DeleteProductCommand genellikle sadece ProductId gerektirir, tüm entity'yi haritalamaya gerek yoktur
            CreateMap<DeleteProductCommand, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ReverseMap(); // Yalnızca ProductId'yi haritalıyoruz
        }
    }
}
