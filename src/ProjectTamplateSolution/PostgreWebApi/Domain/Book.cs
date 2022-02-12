﻿using System;

namespace PostgreWebApi.Domain
{
    public class Book : EntityBase<long>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public DateTime PublicDate { get; set; }
    }
}
