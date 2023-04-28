using Interfaces.Dto;
using MediatR;

namespace MediatorInfrastructure.Commands.Authorization
{
    public class AuthorizationCommand : IRequest<string>
    {
        /// <summary>
        /// Dto из логина и пароля
        /// </summary>
        public LoginDto RequestLoginDto { get; set; }

        /// <summary>
        /// Ключ в виде массива байтов
        /// </summary>
        public byte[] Key { get; set; }

        public AuthorizationCommand(LoginDto requestLoginDto, byte[] key)
        {
            RequestLoginDto = requestLoginDto;
            Key = key;
        }
    }
}
