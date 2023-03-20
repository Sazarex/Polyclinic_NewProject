using MediatR;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommand: IRequest<int>
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
