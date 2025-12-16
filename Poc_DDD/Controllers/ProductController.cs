using Aplication.Handlers.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Poc_DDD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IMediator mediatr;
        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            mediatr = mediator;
        }

        [HttpPost("ProductCreate")]
        public Task<IActionResult> Post([FromForm] ProductCreateCommand request) 
        {
            var res  = mediatr.Send(request);
            return Task.FromResult<IActionResult>(Ok(res));  
        }
    }
}
