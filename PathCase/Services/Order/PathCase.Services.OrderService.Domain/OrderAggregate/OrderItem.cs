using PathCase.Services.OrderService.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.Services.OrderService.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int Quantity { get; private set; }
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, string productId, string productName, decimal price)
        {
            Quantity = quantity;
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public void UpdateOrderItem(int quantity, string productName, decimal price)
        {
            Quantity = quantity;
            ProductName = productName;
            Price = price;
        }
    }
}
