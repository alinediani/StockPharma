using Application.Commands.CreateProduct;
using Application.Commands.DeleteProduct;
using Application.Commands.UpdateProduct;
using Application.Queries.GetAllProducts;
using Application.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProductsQuery = new GetAllProductsQuery(query);

            var products = await _mediator.Send(getAllProductsQuery);

            return Ok(products);
        }

        [HttpPost("/Products/new")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);

            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
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
            var command = new DeleteProductCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
