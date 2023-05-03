using Interfaces.Domain;
using Interfaces.OptionsInterfaces;
using Interfaces.ServiceLayersInterfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Interfaces.ServiceLayers
{
    public class AuthorizationServiceLayer : IAuthorizationService
    {
        /// <summary>
        /// Генерирует jwt-токен
        /// </summary>
        /// <param name="login"></param>
        /// <param name="keyAtBytes"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(Account account, IJWTOptions jWTOptions)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Role, account.Role.ToString()) };
            var jwt = new JwtSecurityToken(jWTOptions.Issuer,
                    jWTOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(jWTOptions.Key), SecurityAlgorithms.HmacSha256));

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
