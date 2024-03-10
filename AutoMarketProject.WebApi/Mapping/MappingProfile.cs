using AutoMapper;
using AutoMarketProject.Domain.Cars;
using AutoMarketProject.Domain.Orders;
using AutoMarketProject.Domain.Users;
using AutoMarketProject.Presentation.Brands;
using AutoMarketProject.Presentation.Cars;
using AutoMarketProject.Presentation.Orders;
using AutoMarketProject.Presentation.Users;

namespace AutoMarketProject.WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.Brand,
                opt => opt.MapFrom(
                    src => src.Brand))
            .ForMember(dest => dest.Model,
                opt => opt.MapFrom(
                    src => src.Model))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom(
                    src => src.Price));

        CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.BrandName,
                opt => opt.MapFrom(
                    src => src.BrandName));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Customer,
                opt => opt.MapFrom(
                    src => src.Customer))
            .ForMember(dest => dest.OrderStatus,
                opt => opt.MapFrom(
                    src => src.OrderStatus))
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(
                    src => src.TotalPrice));
        
        CreateMap<User, UserLoginDto>()
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(
                    src => src.Email))
            .ForMember(dest => dest.Password,
                opt => opt.MapFrom(
                    src => src.PasswordHash));
    }
}