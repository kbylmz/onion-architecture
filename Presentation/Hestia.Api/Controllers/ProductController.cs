using Hestia.Application.Features.Products.Commands.CreateProduct;
using Hestia.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Hestia.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator mediator;
        private ILogger<ProductController> logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            logger.LogInformation($"Id={id}");

            var product = await mediator.Send(new GetProductByIdQuery() { Id = id });

            if (!product.HasValue)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var id = await mediator.Send(command);

            var result = new ObjectResult(id)
            {
                StatusCode = (int)HttpStatusCode.Created
            };

            return result;
        }
    }
}
