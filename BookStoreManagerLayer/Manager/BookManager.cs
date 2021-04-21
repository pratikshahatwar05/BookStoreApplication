using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepo bookRepo;
        public BookManager(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public Book AddBook(Book book)
        {
            try
            {
                return this.bookRepo.AddBook(book);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteBook(int bookId)
        {
            try
            {
                return this.bookRepo.DeleteBook(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Book> GetAllBook()
        {
            try
            {
                return this.bookRepo.GetAllBook();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Book UpdateBook(Book book)
        {
            try
            {
                return this.bookRepo.UpdateBook(book);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
