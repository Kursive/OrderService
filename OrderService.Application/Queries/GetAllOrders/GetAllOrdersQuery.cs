using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Orders;

namespace OrderService.Application.Queries.GetAllOrders
{
    public record GetAllOrdersQuery():IRequest<List<Order>>;
}
