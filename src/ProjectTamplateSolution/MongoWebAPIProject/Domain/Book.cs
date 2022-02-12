using System;

namespace MongoWebAPIProject.Domain
{
    public class Book : EntityBase<long>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public DateTime PublicDate { get; set; }
    }
}
