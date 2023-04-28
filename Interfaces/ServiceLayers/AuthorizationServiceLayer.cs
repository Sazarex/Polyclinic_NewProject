using Interfaces.ServiceLayersInterfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Interfaces.ServiceLayers
{
    public class AuthorizationServiceLayer : IAuthorizationService
    {
        public async Task<string> GetTokenAsync(string login, byte[] keyAtBytes)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, login)};
            var jwt = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(keyAtBytes), SecurityAlgorithms.HmacSha256));

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
