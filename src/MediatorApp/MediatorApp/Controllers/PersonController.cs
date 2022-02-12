using MediatorApp.Models;
using MediatorApp.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _mediator.Send(new GetPersoListQuery());
        }

        [HttpGet("id")]
        public async Task<Person> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery() { Id = id });
        }

    }
}
