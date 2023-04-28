using Interfaces.OptionsInterfaces;

namespace AuthorizationService.Options
{
    public class JWTOptions : IJWTOptions
    {
        public string SecurityKey { get ; set; }
    }
}
