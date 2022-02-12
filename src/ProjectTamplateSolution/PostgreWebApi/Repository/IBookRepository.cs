﻿using PostgreWebApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgreWebApi.Repository
{
    public interface IBookRepository
    {
        Task Create(Book book);
        Task Delete(long id);
        Task Update(Book book);
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(long id);

    }
}