using MediatorApp.Models;
using System.Collections.Generic;

namespace MediatorApp.Repositories
{
    public interface IDataBase
    {
        List<Person> GetPeople();
        Person InsertPerson(string firstName, string lastName);
    }
}