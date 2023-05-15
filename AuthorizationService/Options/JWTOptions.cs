using Interfaces.OptionsInterfaces;

namespace AuthorizationService.Options
{
    public class JWTOptions : IJWTOptions
    {
        public string SecurityKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        
        /// <summary>
        /// Время жизни для jwt access token
        /// </summary>
        public int TokenValidityInMinutes { get; set; }

        /// <summary>
        /// Время жизни рефреш токена
        /// </summary>
        public int RefreshTokenValidityInDays { get; set; }

        /// <summary>
        /// Ключ в массиве байтов
        /// </summary>
        public byte[] Key { get; set; }
    }
}
