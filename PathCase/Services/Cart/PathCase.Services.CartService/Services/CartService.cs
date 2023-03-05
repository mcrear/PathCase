namespace PathCase.Services.CartService.Services
{
    using PathCase.Services.CartService.Dtos;
    using PathCase.Shared.Shared.Dtos;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly RedisService _redisService;

        public CartService(RedisService redisService)
        {
            _redisService = redisService;
        }
        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Cart not found", 404);
        }

        public async Task<Response<CartDto>> GetCart(string userId)
        {
            var existCart = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(existCart))
                return Response<CartDto>.Fail("Cart not found", 404);

            return Response<CartDto>.Success(JsonSerializer.Deserialize<CartDto>(existCart), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(CartDto cart)
        {
            var status = await _redisService.GetDb().StringSetAsync(cart.UserId, JsonSerializer.Serialize(cart));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Cart cannot update or save", 500);
        }
    }
}
