using Microsoft.EntityFrameworkCore;
using SimpleWebAPIProjectThamplate.Domain;

namespace SimpleWebAPIProjectThamplate.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DataBase.db");
        }
    }
}
