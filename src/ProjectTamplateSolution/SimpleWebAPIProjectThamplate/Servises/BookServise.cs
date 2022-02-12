using Microsoft.Extensions.Logging;
using SimpleWebAPIProjectThamplate.Domain;
using SimpleWebAPIProjectThamplate.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleWebAPIProjectThamplate.Servises
{
    public class BookServise : IBookServise
    {
        IBookRepository _bookRepository;
        ILogger<BookServise> _log;

        public BookServise(ILogger<BookServise> log, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _log = log;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(long id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task Create(Book book)
        {
            await _bookRepository.Create(book);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }

        public async Task Delete(long id)
        {
            await _bookRepository.Delete(id);

        }
    }
}
