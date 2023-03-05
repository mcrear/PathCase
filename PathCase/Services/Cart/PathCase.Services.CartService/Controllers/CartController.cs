namespace PathCase.Services.CartService.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PathCase.Services.CartService.Dtos;
    using PathCase.Services.CartService.Services;
    using PathCase.Shared.Shared.CustomController;
    using PathCase.Shared.Shared.Services;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : CustomBaseController
    {
        private readonly ICartService _cartService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CartController(ICartService cartService, ISharedIdentityService sharedIdentityService)
        {
            _cartService = cartService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            return CreateActionResultInstance(await _cartService.GetCart(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateCart(CartDto cart)
        {
            var res = await _cartService.SaveOrUpdate(cart);
            return CreateActionResultInstance(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            return CreateActionResultInstance(await _cartService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
