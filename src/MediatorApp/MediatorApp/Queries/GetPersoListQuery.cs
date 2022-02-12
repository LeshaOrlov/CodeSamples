using MediatorApp.Models;
using MediatR;
using System.Collections.Generic;

namespace MediatorApp.Queries
{
    public class GetPersoListQuery : IRequest<List<Person>> { }

}
