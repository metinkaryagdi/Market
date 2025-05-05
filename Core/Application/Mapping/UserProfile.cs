using AutoMapper;
using Domain.Entities;
using Application.Features.Commands.UserCommands;
using Application.Features.Results.UserResults;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Entity → DTO veya Result
        CreateMap<User, GetUserQueryResult>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));  // Enum'ı string'e dönüştür
        CreateMap<User, GetUserByIdQueryResult>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));  // Enum'ı string'e dönüştür

        // Command → Entity
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.NewGuid()))  // UserId'yi handler dışında burada set et
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))  // CreatedAt'ı burada set etme, handler'da yap
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));  // Enum'ı string olarak map et

        // Güncelleme işlemi için de enum'ı string olarak map et
        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString())); // Enum'ı string olarak map et
    }
}
