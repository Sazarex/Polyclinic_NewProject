using Interfaces.Domain;
using Interfaces.Dto;
using Interfaces.ServiceLayersInterfaces;
using Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using static Interfaces.Common.CommonEnums;

namespace AuthorizationService
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase, IAuthService
    {
        private IPasswordService _passwordService { get; set; }

        public AuthController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public async Task<ActionResult> Login([FromBody] string username, [FromBody] string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Register([FromBody] AccountDto account, [FromBody] string password)
        {

        }
    }
}
