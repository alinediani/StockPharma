using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.GetAllRawMaterials;
using Application.Queries.GetRawMaterialById;
using Application.Commands.CreateRawMaterial;

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

        [HttpPost]
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

    }
}
