using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPostgre.Domain;
using WebApiPostgre.Repository;

namespace WebApiPostgre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(long id)
        {
            return await _bookRepository.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Book book)
        {
            await _bookRepository.Create(book);
        }

        [HttpPut("{id}")]
        public async Task Update(long id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                await _bookRepository.Update(book);
            }

        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _bookRepository.Delete(id);
        }


    }
}
