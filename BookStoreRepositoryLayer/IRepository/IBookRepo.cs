using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IBookRepo
    {
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(Book book);
        List<Book> GetAllBook();
    }
}
