using AuthJWT.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthJWT
{
    public interface ITokenAuthorization
    {
        /// <summary>
        /// Получение токена по информации о пользователе
        /// </summary>
        /// <param name="identity"> Информация о пользователе </param>
        /// <returns >Модель токена </returns>
        Task<Token> GetToken(ClaimsIdentity identity);

        /// <summary>
        /// Обновление токена
        /// </summary>
        /// <param name="oldToken"> Модель старого токена </param>
        /// <returns> Модель нового токена </returns>
        Task<Token> RefreshToken(Token oldToken);
    }
}
