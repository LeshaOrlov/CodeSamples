using MediatorApp.Models;
using MediatR;

namespace MediatorApp.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }

        //public GetPersonByIdQuery(int id)
        //{
           
        //}
    }
}