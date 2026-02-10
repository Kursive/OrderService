using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Application.Interfaces;
using OrderService.Domain.Orders;

namespace OrderService.Application.Commands.CreateOrder
{
        public record CreateOrderCommand(string ProductName,decimal Price):IRequest<Guid>;
}
