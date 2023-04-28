using AuthorizationService.Options;
using Interfaces.Dto;
using MediatorInfrastructure.Commands.Accounts;
using MediatorInfrastructure.Commands.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AuthorizationService
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator { get; set; }
        private JWTOptions _jwtOptions { get; set; }

        public AuthController(IMediator mediator, IOptions<JWTOptions> jwtOptions)
        {
            _mediator = mediator;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("LogIn")]
        public async Task<string> Login([FromBody] LoginDto request)
        {
            return await _mediator.Send(new AuthorizationCommand(request, ConfiguringJWT.GetBytesFromKey(_jwtOptions.SecurityKey)));
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
