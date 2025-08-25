

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Likes.Commands;

namespace Recipes.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("toggle")]
        public async Task<ActionResult<int>> ToggleLike([FromBody] ToggleLikeCommand command)
        {
            var count = await _mediator.Send(command);
            return Ok(count);
        }
    }

}
