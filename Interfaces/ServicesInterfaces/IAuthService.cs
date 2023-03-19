using Interfaces.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ServicesInterfaces
{
    public interface IAuthService
    {
        [HttpPost, Route("Login")]
        public Task<ActionResult> Login([FromBody] string username, [FromBody] string password);

        [HttpPost, Route("Register")]
        public Task<ActionResult> Register([FromBody] AccountDto account, [FromBody] string password);
    }
}
