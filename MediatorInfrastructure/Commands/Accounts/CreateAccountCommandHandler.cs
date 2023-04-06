using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.ServiceLayers;
using MediatR;
using DatabaseInfrastructure.DbContexts;
using Interfaces.Domain;
using static Interfaces.Common.CommonEnums;
using Interfaces.ServiceLayersInterfaces;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private IPasswordService _passwordService;
        private CommandDbContext _commandDbContext;

        public CreateAccountCommandHandler(IPasswordService passwordService, CommandDbContext commandDbContext)
        {
            _passwordService = passwordService;
            _commandDbContext = commandDbContext;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var passHash = new byte[] { };
            var passSalt = new byte[] { };
            _passwordService.CreatePasswordHash(request.Password, out passHash, out passSalt);

            Account newAcc = new Account();
            newAcc.Username = request.Username;
            newAcc.Role = Roles.User;
            newAcc.PasswordHash = passHash;
            newAcc.PasswordSalt = passSalt;
            _commandDbContext.Accounts.Add(newAcc);
            await _commandDbContext.SaveChangesAsync();

            return newAcc.Id;
        }


    }
}
