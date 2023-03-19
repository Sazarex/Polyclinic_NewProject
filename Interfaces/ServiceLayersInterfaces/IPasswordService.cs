using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ServiceLayersInterfaces
{
    public interface IPasswordService
    {
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    }
}
