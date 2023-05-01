using DatabaseInfrastructure.DbContexts;
using Interfaces.ServiceLayersInterfaces;
using MediatR;

namespace MediatorInfrastructure.Commands.Authorization
{
    /// <summary>
    /// Обработчик для авторизации
    /// </summary>
    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand,string>
    {
        #region Зависимости и конструктор для них
        private IAuthorizationService _authorizationService;
        private IPasswordService _passwordService;
        private CommandDbContext _commandDbContext;

        public AuthorizationCommandHandler(IAuthorizationService authorizationService, IPasswordService passwordService, CommandDbContext commandDbContext)
        {
            _authorizationService = authorizationService;
            _passwordService = passwordService;
            _commandDbContext = commandDbContext;
        } 
        #endregion

        /// <summary>
        /// Возвращает jwt-токен, если введенные данные верны.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        async Task<string> IRequestHandler<AuthorizationCommand, string>.Handle(AuthorizationCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.RequestLoginDto.Login))
                throw new UnauthorizedAccessException("Пустой логин пользователя.");

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

            throw new UnauthorizedAccessException("Неверные данные пользователя.");

        }
    }
}
