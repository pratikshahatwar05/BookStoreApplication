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
        int DeleteBook(int bookId);
        List<Book> GetAllBook();
    }
}
