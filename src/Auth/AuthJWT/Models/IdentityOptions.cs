using System;
using System.Collections.Generic;
using System.Text;

namespace AuthJWT.Models
{
    /// <summary>
    /// Настройки для Identity Services
    /// </summary>
    public class IdentityOptions
    {
        /// <summary>
        /// Имя того кем выдаётся токен
        /// </summary>
        public string TokenIssuer { get; set; }

        /// <summary>
        /// Название группы для которой распостраняются токены
        /// </summary>
        public string TokenAudience { get; set; }

        /// <summary>
        /// Время в течении которого живёт токен
        /// </summary>
        public TimeSpan LifeTime { get; set; }

        /// <summary>
        /// Ключ используемый для подписи токена
        /// </summary>
        public string SigningKey { get; set; }
    }
}
