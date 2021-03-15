using AuthApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Cookie.Service
{
    public interface IUserService
    {

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        Task Registration(RegisterModel registrationModel);

        /// <summary>
        /// Регистрация администратора
        /// </summary>
        Task RegistrationAdmin(RegisterModel registrationAdminModel);

        /// <summary>
        /// Авторизация 
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        Task<Token> Authorization(LoginModel authorizationModel);

        // CRUD - Create Read Update Delete
        UserModel GetUser(int Id);

        List<UserShortModel> GetAllUsers();

        void UpdateUser(int Id, UserInfo user);

        Guid CreateUser(UserInfo user);

        void DeleteUser(int Id);

    }
}
