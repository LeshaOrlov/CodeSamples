using AuthJWT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuthJWT
{
    public static class ServiceExtensions
    {
        ///<summary>
        /// Добавление сервисов авторизации
        /// </summary>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, Action<IdentityOptions> configure)
        {
            var options = new IdentityOptions();
            configure(options);
            services.AddSingleton(options);

            //Services
            services.AddScoped<ITokenAuthorization, JwtTokenAuthService>();

            //SessionContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
