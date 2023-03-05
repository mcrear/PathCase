using MediatR;
using PathCase.Services.OrderService.Application.Dtos;
using PathCase.Shared.Shared.Dtos;
using System.Collections.Generic;

namespace PathCase.Services.OrderService.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
