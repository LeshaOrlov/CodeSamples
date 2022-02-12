using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatorApp.Models;
using MediatR;
using MediatorApp.Queries;
using MediatorApp.Repositories;
using System.Linq;

namespace MediatorApp.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IMediator _mediator;
        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPersoListQuery());
            var output = result.Find(x => x.Id == request.Id);
            return output;
        }
    }
}
