using EFC.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC.MSSQL
{
    class MSsqlContext: ApplicationContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
