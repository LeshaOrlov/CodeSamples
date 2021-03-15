using EFC.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC.Mysql
{
    class MySqlContext : ApplicationContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=password;database=usersdb3;");
        }
    }
}
