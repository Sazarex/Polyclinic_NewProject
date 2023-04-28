using AuthorizationService.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthorizationService
{
    public static class ConfiguringJWT
    {
        /// <summary>
        /// Возвращает байты от ключа
        /// </summary>
        /// <param name="key">Стринговый ключ</param>
        /// <returns></returns>
        public static byte[] GetBytesFromKey(string key)
        {
            return Encoding.ASCII.GetBytes(key);
        }

        /// <summary>
        /// Регистрация и конфигурация JWT bearer
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterConfigurationJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //Опции для JWT заносим в сервисы
            services.Configure<JWTOptions>(configuration.GetSection("JWT"));

            //Создается объект JWTOptions
            var jwtOptions = services.BuildServiceProvider().GetRequiredService<IOptions<JWTOptions>>();

            //Получаем байты из JWTOptions для SymmetricSecurityKey 
            var key = GetBytesFromKey(jwtOptions.Value.SecurityKey);

            //Добавляется схема jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //Опции jwt bearer'a
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            return services;
        }
    }
}
