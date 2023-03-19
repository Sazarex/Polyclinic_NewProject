using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Database;
using System.Security.Cryptography;

namespace Polyclinic.Services
{
    public class AuthorizationService
    {
        #region comments
        //private readonly AppDbContext _context;

        //public AuthorizationService(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<AccountDto> Login (string username, string password)
        //{
        //    var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        //    if (account == null)
        //        return null;

        //    if (!VerifyPassword(password, account.PasswordHash, account.PasswordSalt))
        //        return null;

        //    AccountDto accountDto = new AccountDto();
        //    accountDto.Username = account.Username;

        //    return accountDto;

        //}

        //public async Task<Account> Register(AccountDto account, string password)
        //{
        //    byte[] passwordHash, passwordSalt;

        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    Account newAccount = new Account();
        //    newAccount.PasswordHash = passwordHash;
        //    newAccount.PasswordSalt = passwordSalt;
        //    newAccount.Username = account.Username;

        //    if (account.Role.HasFlag(Roles.Administrator))
        //        newAccount.Role = Roles.Administrator;
        //    else
        //        newAccount.Role = Roles.User;

        //    await  _context.Accounts.AddAsync(newAccount);
        //    await _context.SaveChangesAsync();



        //    return newAccount;
        //}


        //public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != passwordHash[i])
        //                return false;
        //        }
        //    }
        //    return true;

        //}

        //public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
        #endregion
    }
}
