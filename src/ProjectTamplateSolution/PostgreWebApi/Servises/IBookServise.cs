using PostgreWebApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgreWebApi.Servises
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