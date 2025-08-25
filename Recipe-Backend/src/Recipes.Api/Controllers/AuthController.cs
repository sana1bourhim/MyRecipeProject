using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Users.Commands.RegisterUser;

namespace Recipes.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { UserId = id });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var user = await _mediator.Send(query);
            if (user == null)
                return Unauthorized("Email ou mot de passe incorrect.");

            return Ok(new { UserId = user.Id, user.Username, user.Email });
        }
    }
}
