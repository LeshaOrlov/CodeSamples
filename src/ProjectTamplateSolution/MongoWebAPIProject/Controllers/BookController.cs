using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoWebAPIProject.Domain;
using MongoWebAPIProject.Repository;
using MongoWebAPIProject.Servises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookServise _bookService;
        public BookController(IBookServise bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(long id)
        {
            return await _bookService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Book book)
        {
            await _bookService.CreateAsync(book);
        }

        [HttpPut("{id}")]
        public async Task Update(long id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                await _bookService.UpdateAsync(book);
            }

        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _bookService.DeleteAsync(id);
        }


    }
}
