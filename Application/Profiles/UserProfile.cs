using AutoMapper;
using Domain;
using Domain.DTOs.Request;
using Domain.DTOs.Response;

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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<User, UserCreatedDTO>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.ToStringFormatted()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MotherName, opt => opt.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));

            CreateMap<User, UserSummaryDTO>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF.ToStringFormatted()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MotherName, opt => opt.MapFrom(src => src.MotherName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            // ? Login
            CreateMap<LoginCreateDTO, Login>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            CreateMap<Login, LoginCreatedDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            CreateMap<Login, LoginSummaryDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            // ? Address

            CreateMap<Address, AddressCreatedDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.IsDefault))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street));

            CreateMap<Address, AddressSummaryDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.IsDefault))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street));
        }
    }
}