using static Interfaces.Common.CommonEnums;

namespace Interfaces.Domain
{
    public class Account: BaseEntity
    {
        public string Username { get; set; }
        public Roles? Role { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }
}
