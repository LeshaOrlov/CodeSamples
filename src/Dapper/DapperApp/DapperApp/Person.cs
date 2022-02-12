using System;
using System.Collections.Generic;
using System.Text;

namespace DapperApp
{
    internal class Person
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    internal class Person2
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
