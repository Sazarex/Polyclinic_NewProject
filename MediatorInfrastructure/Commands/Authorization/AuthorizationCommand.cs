using Interfaces.Dto;
using Interfaces.OptionsInterfaces;
using MediatR;

namespace MediatorInfrastructure.Commands.Authorization
{
    public class AuthorizationCommand : IRequest<string>
    {
        /// <summary>
        /// Dto из логина и пароля
        /// </summary>
        public LoginDto RequestLoginDto { get; set; }

        public IJWTOptions JWTOptions { get; set; }

        public AuthorizationCommand(LoginDto requestLoginDto, IJWTOptions jwtOptions)
        {
            RequestLoginDto = requestLoginDto;
            JWTOptions = jwtOptions;
        }
    }
}
