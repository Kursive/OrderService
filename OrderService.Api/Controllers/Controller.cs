using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Commands.CancelOrder;
using OrderService.Application.Commands.CreateOrder;
using OrderService.Application.DTos.Requests;
using OrderService.Application.DTos.Responses;
using OrderService.Application.Queries.GetAllOrders;
using OrderService.Application.Queries.GetOrderById;
using OrderService.Domain.Orders;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));

            var response = new OrderResponse(
                order.Id,
                order.Status,
                order.Items.Select(i => new OrderItemResponse(
                    i.ProductName,
                    i.Price,
                    i.Created
                )).ToList()
            );

            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAll()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            var response = orders.Select(order => new OrderResponse(
                order.Id,
                order.Status,
                order.Items.Select(i => new OrderItemResponse(
                   i.ProductName,
                   i.Price,
                   i.Created
                )).ToList()
            )).ToList();

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateOrderRequestDto dto)
        {
            var command = new AddOrderItemRequest(
                dto.Productname,
                dto.Price
            );

            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Cancel(Guid id)
        => Ok(await _mediator.Send(new CancelOrderCommand(id)));
    }
}
