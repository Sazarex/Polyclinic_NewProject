using Interfaces.ServiceLayersInterfaces;
using System.Security.Cryptography;
using System.Text;

namespace Interfaces.ServiceLayers
{
    public class PasswordServiceLayer : IPasswordService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Проверка верности пароля
        /// </summary>
        /// <param name="password">Пароль, полученный от клиента</param>
        /// <param name="passwordHash">Хэш пароля из бд</param>
        /// <param name="passwordSalt">Соль хэша пароля из бд</param>
        /// <returns>true - верный пароль</returns>
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //Создается класс для работы с хэшем на основе соли из бд
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                //Делаем хэш полученного пароля (используется соль при создании класса выше)
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Сравнивается созданный хэш полученного пароля с хэшем пароля из бд
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
