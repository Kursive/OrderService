using MediatR;
using OrderService.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Commands.CancelOrder
{
    public record CancelOrderCommand(Guid id ): IRequest<Guid>;//
}
