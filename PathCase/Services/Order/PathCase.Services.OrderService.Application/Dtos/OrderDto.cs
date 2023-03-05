using System;
using System.Collections.Generic;

namespace PathCase.Services.OrderService.Application.Dtos
{
    public class OrderDto
    {
        public DateTime CreatedDate { get; set; }
        public AddressDto Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

    }
}
