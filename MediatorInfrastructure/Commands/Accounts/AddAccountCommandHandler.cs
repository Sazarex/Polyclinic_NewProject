using DatabaseInfrastructure.DbContexts;
using Interfaces.Common;
using Interfaces.Domain;
using MediatR;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand, int>
    {
        private CommandDbContext _commandDbContext;

        public AddAccountCommandHandler(CommandDbContext commandDbContext)
        {
            _commandDbContext = commandDbContext;
        }

        /// <summary>
        /// Добавление аккаунта в бд
        /// </summary>
        public async Task<int> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            Account newAcc = new Account();
            newAcc.Username = request.Username;
            newAcc.Role = Role.User;
            newAcc.PasswordHash = request.PasswordHash;
            newAcc.PasswordSalt = request.PasswordSalt;
            _commandDbContext.Accounts.Add(newAcc);
            await _commandDbContext.SaveChangesAsync();

            return newAcc.Id;
        }
    }
}
