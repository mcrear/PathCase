using MediatR;
using PathCase.Services.OrderService.Application.Commands;
using PathCase.Services.OrderService.Application.Dtos;
using PathCase.Services.OrderService.Domain.OrderAggregate;
using PathCase.Services.OrderService.Infrastacture;
using PathCase.Shared.Shared.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Description);

            Order newOrder = new Order(newAddress, request.BuyerId);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.Quantity, x.ProductId, x.ProductName, x.Price);
            });

            await _context.Orders.AddAsync(newOrder);

            var res = await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
