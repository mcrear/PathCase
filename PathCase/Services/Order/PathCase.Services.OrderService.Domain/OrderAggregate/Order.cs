using PathCase.Services.OrderService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; set; }
        public Address Address { get; set; }
        public string BuyerId { get; set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {

        }

        public Order(Address address, string buyerId)
        {
            CreatedDate = DateTime.Now;
            Address = address;
            BuyerId = buyerId;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(int quantity, string productId, string productName, decimal price)
        {
            var existItem = _orderItems.Any(x => x.ProductId == productId);

            if (!existItem)
            {
                var newOrderItem = new OrderItem(quantity, productId, productName, price);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
