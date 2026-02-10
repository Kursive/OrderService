using OrderService.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTos.Responses
{
    public record OrderResponse(Guid Id, OrderStatus Status, IReadOnlyCollection<OrderItemResponse> Items);// лучше IReadOnlyCollection 
    //что клиент получил все заказы 

}
