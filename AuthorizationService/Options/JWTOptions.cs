using Interfaces.OptionsInterfaces;

namespace AuthorizationService.Options
{
    public class JWTOptions : IJWTOptions
    {
        public string SecurityKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }

        /// <summary>
        /// Ключ в массиве байтов
        /// </summary>
        public byte[] Key { get; set; }
    }
}
