using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.GetAllRawMaterials;
using Application.Queries.GetRawMaterialById;
using Application.Commands.CreateRawMaterial;
using Application.Commands.UpdateRawMaterial;
using Application.Commands.DeleteRawMaterial;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/RawMaterials")]
    public class RawMaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RawMaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllRawMaterialsQuery = new GetAllRawMaterialsQuery(query);

            var rawMaterials = await _mediator.Send(getAllRawMaterialsQuery);

            return Ok(rawMaterials);
        }

        [HttpPost("/RawMaterials/new")]
        public async Task<IActionResult> Post([FromBody] CreateRawMaterialCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRawMaterialByIdQuery(id);

            var rawMaterial = await _mediator.Send(query);

            if (rawMaterial == null)
            {
                return NotFound();
            }

            return Ok(rawMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRawMaterialCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRawMaterialCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
