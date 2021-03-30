﻿using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookRepo : IBookRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public BookRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public Book AddBook(Book book)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookName", book.BookName);
                    command.Parameters.AddWithValue("@BookAutherName", book.BookAutherName);
                    command.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    command.Parameters.AddWithValue("@BookImage", book.BookImage);
                    command.Parameters.AddWithValue("@BookDescription", book.BookDescription);
                    command.Parameters.AddWithValue("@BookQuantity", book.BookQuantity);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return book;
                    return null;
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public Book UpdateBook(Book book)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("sp_update_book", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", book.BookId);
                    command.Parameters.AddWithValue("@BookName", book.BookName);
                    command.Parameters.AddWithValue("@BookAutherName", book.BookAutherName);
                    command.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    command.Parameters.AddWithValue("@BookImage", book.BookImage);
                    command.Parameters.AddWithValue("@BookDescription", book.BookDescription);
                    command.Parameters.AddWithValue("@BookQuantity", book.BookQuantity);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return book;
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public Book DeleteBook(Book book)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("sp_delete_book", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", book.BookId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return book;
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<Book> GetAllBook()
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("GetAllBook", this.connection);
                    List<Book> book = new List<Book>();
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Book getBook = new Book();
                        getBook.BookId = (int)dataReader["BookId"];
                        getBook.BookName = dataReader["BookName"].ToString();
                        getBook.BookAutherName = dataReader["BookAutherName"].ToString();
                        getBook.BookPrice = (int)dataReader["BookPrice"];
                        getBook.BookImage = dataReader["BookImage"].ToString();
                        getBook.BookDescription = dataReader["BookDescription"].ToString();
                        getBook.BookQuantity = (int)dataReader["BookQuantity"];
                        book.Add(getBook);
                    }
                    return book;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
