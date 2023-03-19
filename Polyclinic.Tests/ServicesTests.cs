using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Polyclinic.Database;
using Polyclinic.Services;

namespace Polyclinic.Tests
{
    public class ServicesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckPasswordsMethods([Values("qwerty", "123451")] string password)
        {
            //var service = new AuthorizationService(new AppDbContext(new DbContextOptions <AppDbContext> ()));
            //byte[] passwordHash, passwordSalt;
            //service.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //var isCorrectPassword = service.VerifyPassword(password, passwordHash, passwordSalt);
            //var hash = System.Text.Encoding.UTF8.GetString(passwordHash);
            //var salt = System.Text.Encoding.UTF8.GetString(passwordSalt);
            //Assert.AreEqual(hash, salt);


            //Assert.IsTrue(isCorrectPassword);
        }
    }
}