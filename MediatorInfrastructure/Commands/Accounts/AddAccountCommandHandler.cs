using DatabaseInfrastructure.DbContexts;
using Interfaces.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Common.CommonEnums;

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
            newAcc.Role = Roles.User;
            newAcc.PasswordHash = request.PasswordHash;
            newAcc.PasswordSalt = request.PasswordSalt;
            _commandDbContext.Accounts.Add(newAcc);
            await _commandDbContext.SaveChangesAsync();

            return newAcc.Id;
        }
    }
}
