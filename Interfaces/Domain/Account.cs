using Interfaces.Common;

namespace Interfaces.Domain
{
    public class Account: BaseEntity
    {
        public string Username { get; set; }
        public Role? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
