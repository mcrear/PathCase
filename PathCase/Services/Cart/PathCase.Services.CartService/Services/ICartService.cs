namespace PathCase.Services.CartService.Services
{
    using PathCase.Services.CartService.Dtos;
    using PathCase.Shared.Shared.Dtos;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<Response<CartDto>> GetCart(string userId);
        Task<Response<bool>> SaveOrUpdate(CartDto cart);
        Task<Response<bool>> Delete(string userId);
    }
}
