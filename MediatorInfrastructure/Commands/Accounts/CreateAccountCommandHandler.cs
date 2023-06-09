﻿using MediatR;
using DatabaseInfrastructure.DbContexts;
using Interfaces.Domain;
using Interfaces.ServiceLayersInterfaces;
using Interfaces.Common;
using Microsoft.AspNetCore.Mvc;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, IActionResult>
    {
        private IPasswordService _passwordService;
        private CommandDbContext _commandDbContext;

        public CreateAccountCommandHandler(IPasswordService passwordService, CommandDbContext commandDbContext)
        {
            _passwordService = passwordService;
            _commandDbContext = commandDbContext;
        }

        public async Task<IActionResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            if (_commandDbContext.Accounts.Any(a => a.Email == request.Email))
                return new BadRequestObjectResult("Почта занята.");

            if (_commandDbContext.Accounts.Any(a => a.Username == request.Username))
                return new BadRequestObjectResult("Логин занят.");


            var passHash = new byte[] { };
            var passSalt = new byte[] { };
            _passwordService.CreatePasswordHash(request.Password, out passHash, out passSalt);

            Account newAcc = new Account();
            newAcc.Name = request.Name;
            newAcc.Patronymic = request.Patronymic;
            newAcc.Surname = request.Surname;
            newAcc.Sex = request.Sex;
            newAcc.Email = request.Email;
            newAcc.Username = request.Username;
            newAcc.Role = Role.User;
            newAcc.PasswordHash = passHash;
            newAcc.PasswordSalt = passSalt;
            _commandDbContext.Accounts.Add(newAcc);
            await _commandDbContext.SaveChangesAsync();

            return new OkResult();
        }


    }
}
