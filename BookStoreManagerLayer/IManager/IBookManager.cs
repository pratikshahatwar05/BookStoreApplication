using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IBookManager
    {
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        int DeleteBook(int bookId);
        List<Book> GetAllBook();
    }
}
