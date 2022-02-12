using Dapper;
using Npgsql;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DapperApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var connection = new NpgsqlConnection("Server=localhost:5432;Database=postgres;User Id=postgres;Password=example;"))
            {
                var person = connection.Query<Person>("SELECT * FROM Person").ToList();
                Console.WriteLine(JsonSerializer.Serialize(person));
                var person2 = connection.Query<Person2>("SELECT * FROM Person").ToList();
                Console.WriteLine(JsonSerializer.Serialize(person2));
            }
            
        }
    }
}
