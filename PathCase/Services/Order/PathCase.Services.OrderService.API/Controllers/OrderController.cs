using MediatR;
using Microsoft.AspNetCore.Mvc;
using PathCase.Services.OrderService.Application.Commands;
using PathCase.Services.OrderService.Application.Queries;
using PathCase.Shared.Shared.CustomController;
using PathCase.Shared.Shared.Services;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _shearedIdentityService;

        public OrderController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _shearedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var res = await _mediator.Send(new GetOrdersByUserIdQuery() { UserId = _shearedIdentityService.GetUserId });

            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var res = await _mediator.Send(command);

            return CreateActionResultInstance(res);
        }
    }
}
