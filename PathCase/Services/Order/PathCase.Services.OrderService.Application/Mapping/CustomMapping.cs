using AutoMapper;
using PathCase.Services.OrderService.Application.Dtos;
using PathCase.Services.OrderService.Domain.OrderAggregate;

namespace PathCase.Services.OrderService.Application.Mapping
{
    public class CustomMapping : Profile
    {

        public CustomMapping()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
