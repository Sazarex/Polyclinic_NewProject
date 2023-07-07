using Interfaces.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommand: IRequest<IActionResult>
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; set; }

    }
}
