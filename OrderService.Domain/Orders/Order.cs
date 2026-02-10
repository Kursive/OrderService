using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Orders;

namespace OrderService.Domain.Orders
{
    public  class Order
    {
        private readonly List<OrderItem> _items = new();

        public Guid Id { get; }
        public OrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items;
        private Order() { } // нужен для EF Core

        public Order(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Status = OrderStatus.Draft;
        }

        public void Create(OrderItem item)
        {
            if (Status != OrderStatus.Draft)
                throw new InvalidOperationException("Нельзя менять заказ не в Draft");

            _items.Add(item);
        }

        public void Active()
        {
            if (Status != OrderStatus.Draft)
                throw new InvalidOperationException("Подтвердить можно только Draft");

            if (_items.Count == 0)
                throw new InvalidOperationException("Нельзя подтвердить пустой заказ");

            Status = OrderStatus.Confirmed;
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Canceled)
                throw new InvalidOperationException("Заказ уже отменён");

            Status = OrderStatus.Canceled;
        }
    }
}
