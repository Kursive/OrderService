using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Domain.Orders;

namespace OrderService.Application.Commands.CancelOrder
{
    public class CancelOrderCommandHandler: IRequestHandler<CancelOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CancelOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Handle( CancelOrderCommand request,CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.id,cancellationToken) ?? throw new InvalidOperationException("Заказ не найден");
            order.Cancel();
            await _orderRepository.SaveChangeAsync(cancellationToken);
            return order.Id;
        }//
    }
}
