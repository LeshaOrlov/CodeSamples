using EFC.Database.Models;
using EFC.SQLite.Models;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace EFC.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new SQLiteContext()) {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList<User>();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            };
            
        }
    }
}
