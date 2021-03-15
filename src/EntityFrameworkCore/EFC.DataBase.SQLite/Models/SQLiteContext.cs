using EFC.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC.Database.SQLite
{
    public class SQLiteContext : ApplicationContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DataBase.db");
        }
    }
}
