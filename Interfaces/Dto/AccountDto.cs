using Interfaces.Domain;
using static Interfaces.Common.CommonEnums;

namespace Interfaces.Dto
{
    public class AccountDto:BaseEntity
    {
        public string Username { get; set; }
        public Roles Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
