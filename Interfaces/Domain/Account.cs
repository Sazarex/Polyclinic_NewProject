using Interfaces.Common;

namespace Interfaces.Domain
{
    public class Account: BaseEntity
    {

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
        public string Username { get; set; }
        public Role? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime? CreateDate { get; set; }
        
        public string Email { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public string Sex { get; set; }
    }
}
