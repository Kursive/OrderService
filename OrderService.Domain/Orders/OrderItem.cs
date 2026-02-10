
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Orders
{
    public  class OrderItem
    {
        public string ProductName { get; }
        public decimal Price { get;  }
        public DateTime Created { get; }

        public OrderItem(string productName, decimal price)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new Exception("Название продукта не может быть пустым");

            if (price <= 0)
                throw new Exception("Цена должна быть больше нуля");

            ProductName = productName;
            Price = price;
            Created = DateTime.UtcNow;
        }
        public OrderItem() { }
        public override bool Equals(object? obj)
        {
            if (obj is not OrderItem other)
                return false;
            return ProductName == other.ProductName
                   && Price == other.Price;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Price);
        }
    }
}
