using DatabaseInfrastructure.DbContexts;
using Interfaces.ServiceLayersInterfaces;
using MediatR;

namespace MediatorInfrastructure.Commands.Authorization
{
    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand,string>
    {
        private IAuthorizationService _authorizationService;
        private IPasswordService _passwordService;
        private CommandDbContext _commandDbContext;

        public AuthorizationCommandHandler(IAuthorizationService authorizationService, IPasswordService passwordService, CommandDbContext commandDbContext)
        {
            _authorizationService = authorizationService;
            _passwordService = passwordService;
            _commandDbContext = commandDbContext;
        }

        async Task<string> IRequestHandler<AuthorizationCommand, string>.Handle(AuthorizationCommand command, CancellationToken cancellationToken)
        {
            //Сущность из дб по логину
            var entityFromDb = _commandDbContext.Accounts.FirstOrDefault(a => a.Username == command.RequestLoginDto.Login);

            if (entityFromDb != null)
            {
                //подтверждаем полученный пароль с паролем сущности из бд
                var isCorrectPassword = _passwordService.VerifyPassword(command.RequestLoginDto.Password, entityFromDb.PasswordHash, entityFromDb.PasswordSalt);

                //Отдаем токен если верный пароль
                if (isCorrectPassword)
                return await _authorizationService.GetTokenAsync(command.RequestLoginDto.Login, command.Key);
            }

            throw new UnauthorizedAccessException("Invalid credentials");

        }
    }
}
