using System;

Person person = new Person() { Name = "Bob" };
Console.WriteLine(person.Name);
Method(person);
Console.WriteLine(person.Name);

MethodRef(ref person);
Console.WriteLine(person.Name);

Console.ReadLine();

static void Method(Person person)
{
    person = new Person() { Name = "Sam" };
}

static void MethodRef(ref Person person)
{
    person = new Person() { Name = "Ivan" };
}

class Person
{
    public string Name { get; set; }
}
