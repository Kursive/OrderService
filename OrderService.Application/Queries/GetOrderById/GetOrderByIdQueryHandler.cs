using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Domain.Orders;

namespace OrderService.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {   
        public readonly IOrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository) 
        {
        _orderRepository = orderRepository;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var xd = await _orderRepository.GetByIdAsync(request.id, cancellationToken) ?? throw new ArgumentNullException("Заказ не найден");  
        return xd;
        }//
    }
}
