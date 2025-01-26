using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Queries.GetAllRawMaterials;

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

            var projects = await _mediator.Send(getAllRawMaterialsQuery);

            return Ok(projects);
        }

    }
}
