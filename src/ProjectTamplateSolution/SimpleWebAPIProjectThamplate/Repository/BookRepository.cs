using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleWebAPIProjectThamplate.Data;
using SimpleWebAPIProjectThamplate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPIProjectThamplate.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> _log;
        private readonly DataContext _context;
        public BookRepository(ILogger<BookRepository> log, DataContext context)
        {
            _log = log;
            _context = context;
            
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetById(long id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            _log.LogInformation($"New book has been created: {book.Title}");
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            _log.LogInformation($"New  has been created: {book.Title}");
        }

        public async Task Delete(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
