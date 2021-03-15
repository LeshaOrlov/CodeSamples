using EFC.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC.PGSql
{
    class PGSqlContext : ApplicationContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=111");
        }
    }
}
