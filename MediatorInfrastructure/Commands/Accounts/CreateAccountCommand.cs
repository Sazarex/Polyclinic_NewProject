using MediatR;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommand: IRequest<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
