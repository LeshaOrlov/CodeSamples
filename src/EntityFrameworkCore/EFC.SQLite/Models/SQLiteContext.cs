using Microsoft.EntityFrameworkCore;
using EFC.Database.Models;

namespace EFC.SQLite.Models
{
    public class SQLiteContext : ApplicationContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DataBase.db");
        }
    }
}
