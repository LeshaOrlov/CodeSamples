using SimpleWebAPIProjectThamplate.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleWebAPIProjectThamplate.Repository
{
    public interface IBookRepository
    {
        Task Create(Book book);
        Task Delete(long id);
        Task Update(Book book);
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(long id);
        
    }
}