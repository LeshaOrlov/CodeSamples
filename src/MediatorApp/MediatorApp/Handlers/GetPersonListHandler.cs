using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatorApp.Models;
using MediatR;
using MediatorApp.Queries;
using MediatorApp.Repositories;

namespace MediatorApp.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetPersoListQuery, List<Person>>
    {
        private readonly IDataBase _data;
        public GetPersonListHandler(IDataBase data)
        {
            _data = data;
        }
        public Task<List<Person>> Handle(GetPersoListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetPeople());
        }
    }
}
