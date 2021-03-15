using Auth.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Cookie.Service
{
    public class UserService
    {
        private readonly ApplicationContext _db;
        public UserService(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Token> Authorization(AuthorizationModel authorizationModel)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(x => x.Login == authorizationModel.Login);
            if (existingUser != null)
            {
                if ((authorizationModel.Password + existingUser.PasswordSalt) == existingUser.PasswordHash)
                {
                    var identity = new ClaimsIdentity(new GenericIdentity(authorizationModel.Login), new[] { new Claim("login", authorizationModel.Login), new Claim("email", existingUser.Email ?? string.Empty) });
                    var token = await _tokenAuthorizationService.GetToken(identity);
                    return token;
                }
                else
                {
                    throw new Exception("Неверный пароль");
                }
            }
            else
            {
                throw new Exception("Пользователь с таким логином не найден");
            }
        }

        public async Task Registration(RegistrationModel registrationModel)
        {
            var salt = new Random();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Type = UserType.User,
                Login = registrationModel.Login,
                Email = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                PasswordSalt = salt.GenerateSalt(),
                PasswordHash = (registrationModel.Password + salt)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public void RegistrationAdmin()
        {
           
        }

        public void CreateUser()
        {
            
        }

        public void DeleteUser(int Id)
        {

        }

        public List<Users> GetAllUsers()
        {
            var users = _dbContext.Users;

            var resultUsers = new List<UserShortModel>();

            foreach (var dbUser in users)
            {
                var user = new UserShortModel()
                {
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Id = dbUser.Id,
                    Type = dbUser.Type
                };
                resultUsers.Add(user);
            }

            return resultUsers;
        }

        public UserModel GetUser(Guid Id)
        {
            var dbUser = _dbContext.Users.First(e => e.Id == Id);

            var user = new UserModel()
            {
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Id = dbUser.Id,
                Type = dbUser.Type

            };

            return user;
        }

        public void UpdateUser(Guid Id, UserInfo userInfo)
        {
            var user = _dbContext.Users.First(e => e.Id == Id);

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Type = userInfo.Type;

            _dbContext.SaveChanges();
        }


    }
}
