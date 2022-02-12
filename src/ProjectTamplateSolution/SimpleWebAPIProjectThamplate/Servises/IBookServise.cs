using SimpleWebAPIProjectThamplate.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleWebAPIProjectThamplate.Servises
{
    public interface IBookServise
    {
        Task Create(Book book);
        Task Delete(long id);
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(long id);
        Task Update(Book book);
    }
}