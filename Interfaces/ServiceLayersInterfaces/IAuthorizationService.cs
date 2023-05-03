using Interfaces.Domain;
using Interfaces.OptionsInterfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ServiceLayersInterfaces
{
    public interface IAuthorizationService
    {
        public Task<string> GetTokenAsync(Account account, IJWTOptions jWTOptions);

    }
}
