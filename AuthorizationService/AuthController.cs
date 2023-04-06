using Interfaces.Domain;
using Interfaces.Dto;
using Interfaces.ServiceLayersInterfaces;
using Interfaces.ServicesInterfaces;
using MediatorInfrastructure.Commands.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Interfaces.Common.CommonEnums;

namespace AuthorizationService
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator { get; set; }

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //public async Task<ActionResult> Login([FromBody] string username, [FromBody] string password)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
