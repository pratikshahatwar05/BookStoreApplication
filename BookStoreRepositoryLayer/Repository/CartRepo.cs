using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public CartRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public Cart AddCart(Cart cart)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddCart", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", cart.BookId);
                    command.Parameters.AddWithValue("@UserId", cart.UserId);
                    command.Parameters.AddWithValue("@BookQuantity", cart.BookQuantity);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return cart;
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

        public Cart UpdateCart(Cart cart)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateCart", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cart.CartId);
                    command.Parameters.AddWithValue("@BookId", cart.BookId);
                    command.Parameters.AddWithValue("@UserId", cart.UserId);
                    command.Parameters.AddWithValue("@BookQuantity", cart.BookQuantity);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return cart;
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

        public int DeleteCart(int cartId, int userId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteCart", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cartId);
                    command.Parameters.AddWithValue("@UserId", userId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    return cartId;
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

        public List<CartResponse> GetAllCart(int userId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllCart", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    List<CartResponse> cartRsponse = new List<CartResponse>();
                    CartResponse cart = new CartResponse();
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            cart.CartId = (int)dataReader["CartId"];
                            cart.BookQuantity = (int)dataReader["BookQuanity"];
                            cart.UserId = (int)dataReader["UserId"];
                            cart.BookName = dataReader["BookName"].ToString();
                            cart.BookAutherName = dataReader["BookAutherName"].ToString();
                            cart.BookPrice = (int)dataReader["BookPrice"];
                            cart.BookImage = dataReader["BookImage"].ToString();
                            cartRsponse.Add(cart);
                            break;
                        }
                    }
                    return cartRsponse;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
