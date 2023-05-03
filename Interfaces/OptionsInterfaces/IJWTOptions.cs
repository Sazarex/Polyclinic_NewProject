using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.OptionsInterfaces
{
    public interface IJWTOptions
    {
        /// <summary>
        /// Секретный ключ из файла с setting'ами json
        /// </summary>
        public string SecurityKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

        /// <summary>
        /// Ключ в массиве байтов, для credentials
        /// </summary>
        public byte[] Key { get; set; }
    }
}
