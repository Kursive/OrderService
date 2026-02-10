using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Application.Commands;
using OrderService.Domain.Orders;
using OrderService.Application.Interfaces;

namespace OrderService.Application.Commands.CreateOrder
{
    public  class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand, Guid>
    {

        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand command,CancellationToken cancellationToken)
        {
            var order = new Order(Guid.Empty);
            var item = new OrderItem(command.ProductName,  command.Price);
            order.Create(item);
            await _orderRepository.CreateOrder(order, cancellationToken);
            return order.Id;
        }
    }
}
