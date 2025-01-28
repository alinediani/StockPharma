using Application.Commands.CreateClient;
using Application.Commands.DeleteClient;
using Application.Commands.UpdateClient;
using Application.Queries.GetAllClients;
using Application.Queries.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/Clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllClientsQuery = new GetAllClientsQuery(query);

            var clients = await _mediator.Send(getAllClientsQuery);

            return Ok(clients);
        }

        [HttpPost("/Clients/new")]
        public async Task<IActionResult> Post([FromBody] CreateClientCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetClientByIdQuery(id);

            var client = await _mediator.Send(query);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClientCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClientCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
