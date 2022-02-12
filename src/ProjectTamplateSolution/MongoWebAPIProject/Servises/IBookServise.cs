using MongoWebAPIProject.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoWebAPIProject.Servises
{
    public interface IBookServise
    {
        Task CreateAsync(Book book);
        Task DeleteAsync(long id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(long id);
        Task UpdateAsync(Book book);
    }
}