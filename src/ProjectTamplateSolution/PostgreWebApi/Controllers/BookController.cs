using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgreWebApi.Domain;
using PostgreWebApi.Repository;
using PostgreWebApi.Servises;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgreWebApi.Controllers
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
            return await _bookService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(long id)
        {
            return await _bookService.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] Book book)
        {
            await _bookService.Create(book);
        }

        [HttpPut("{id}")]
        public async Task Update(long id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                await _bookService.Update(book);
            }

        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _bookService.Delete(id);
        }


    }
}
