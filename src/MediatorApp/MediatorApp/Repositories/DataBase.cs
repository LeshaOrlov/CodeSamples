using MediatorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MediatorApp.Repositories
{
    public class DataBase : IDataBase
    {
        readonly List<Person> people = new List<Person>();

        public DataBase()
        {
            people.Add(new Person() { Id = 1, FirstName = "Alexey", LastName = "Orlov" });
            people.Add(new Person() { Id = 2, FirstName = "Ivan", LastName = "Ivanov" });
            people.Add(new Person() { Id = 3, FirstName = "Petr", LastName = "Petrov" });
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public Person InsertPerson(string firstName, string lastName)
        {
            Person person = new Person() { FirstName = firstName, LastName = lastName };
            person.Id = people.Max(x => x.Id) + 1;
            people.Add(person);
            return person;
        }


    }
}
