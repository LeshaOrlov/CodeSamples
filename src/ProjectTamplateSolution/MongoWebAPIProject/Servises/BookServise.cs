using Microsoft.Extensions.Logging;
using MongoWebAPIProject.Domain;
using MongoWebAPIProject.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoWebAPIProject.Servises
{
    public class BookServise : IBookServise
    {
        IRepository _bookRepository;
        ILogger<BookServise> _log;

        public BookServise(ILogger<BookServise> log, IRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _log = log;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.AllAsync<Book>();
        }

        public async Task<Book> GetByIdAsync(long id)
        {
            return await _bookRepository.SingleAsync<Book>(x => x.Id == id);
        }

        public async Task CreateAsync(Book book)
        {
            await _bookRepository.AddAsync<Book>(book);
        }

        public async Task UpdateAsync(Book book)
        {
            await _bookRepository.UpdateAsync<Book>(x => x.Id == book.Id, book);
        }

        public async Task DeleteAsync(long id)
        {
            await _bookRepository.DeleteAsync<Book>(x => x.Id == id);

        }

    }
}
