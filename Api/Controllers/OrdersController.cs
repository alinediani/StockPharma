using Application.Commands.CreateOrder;
using Application.Commands.DeleteOrder;
using Application.Commands.UpdateOrder;
using Application.Queries.GetAllOrders;
using Application.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllOrdersQuery = new GetAllOrdersQuery(query);

            var orders = await _mediator.Send(getAllOrdersQuery);

            return Ok(orders);
        }

        [HttpPost("/Orders/new")]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetOrderByIdQuery(id);

            var order = await _mediator.Send(query);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOrderCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrderCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
