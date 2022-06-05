using Application.DTOs.Request;
using AutoMapper;
using Domain;

namespace Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.MotherName, opt => opt.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            ;
        }
    }
}