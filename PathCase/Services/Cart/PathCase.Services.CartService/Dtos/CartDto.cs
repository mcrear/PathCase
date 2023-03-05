namespace PathCase.Services.CartService.Dtos
{
    using System.Collections.Generic;
    using System.Linq;

    public class CartDto
    {
        public string UserId { get; set; }
        public List<CartItemDto> cartItems { get; set; }
        public decimal TotalPrice { get => cartItems.Sum(x => x.Price * x.Price); }
    }
}
