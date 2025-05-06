using Application.Features.Commands.CategoryCommands;
using Application.Features.Commands.ProductCommands;
using Application.Features.Commands.UserCommands;
using Application.Features.Queries.CategoryQueries;
using Application.Features.Results.CategoryResults;
using Application.Features.Results.ProductResults;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<DeleteCategoryCommand, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap(); 
        }
    }
}
