using Auth.Database;
using AuthApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Cookie.Service
{
    public class CookieAuthService
    {
        private readonly ApplicationContext _db; 
        public CookieAuthService(ApplicationContext db)
        {
            _db = db;
        }

        public async void Register(RegisterModel model)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                // добавляем пользователя в бд
                user = new User { Email = model.Email, Password = model.Password };
                Role userRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                if (userRole != null)
                    user.Role = userRole;

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                await Authenticate(user);
            }
        }

        public ClaimsIdentity Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return 
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
