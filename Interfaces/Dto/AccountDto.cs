using Interfaces.Common;
using Interfaces.Domain;

namespace Interfaces.Dto
{
    public class AccountDto:BaseEntity
    {
        public string Username { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
