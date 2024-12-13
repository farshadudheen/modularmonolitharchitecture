using DemoApp.Application.Commands;
using DemoApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Product added successfully");
        }
    }
}
