using MediatR;
using Microsoft.EntityFrameworkCore;
using PathCase.Services.OrderService.Application.Dtos;
using PathCase.Services.OrderService.Application.Mapping;
using PathCase.Services.OrderService.Application.Queries;
using PathCase.Services.OrderService.Infrastacture;
using PathCase.Shared.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDbContext _context;
        public GetOrdersByUserIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

            if (!orders.Any())
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);

            var orderDtoList = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return Response<List<OrderDto>>.Success(orderDtoList, 200);
        }
    }
}
