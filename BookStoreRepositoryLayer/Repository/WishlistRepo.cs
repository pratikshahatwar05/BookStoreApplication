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
    public class WishlistRepo : IWishlistRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;
        public WishlistRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public Wishlist AddWishlist(Wishlist wishlist)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddWishlist", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", wishlist.UserId);
                    command.Parameters.AddWithValue("@BookId", wishlist.BookId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return wishlist;
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

        public int DeleteWishlist(int userId, int bookId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteWishlist", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result;
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

        public List<WishlistResponse> GetAllWishlist(int userId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllWishlist",this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    List<WishlistResponse> wishlistResponse = new List<WishlistResponse>();
                    WishlistResponse wishlist = new WishlistResponse();
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            wishlist.WishlistId = (int)dataReader["WishlistId"];
                            wishlist.UserId = (int)dataReader["UserId"];
                            wishlist.BookName = dataReader["BookName"].ToString();
                            wishlist.BookAutherName = dataReader["BookAutherName"].ToString();
                            wishlist.BookPrice = (int)dataReader["BookPrice"];
                            wishlist.BookImage = dataReader["BookImage"].ToString();
                            wishlistResponse.Add(wishlist);
                            break;
                        }
                    }
                    return wishlistResponse;
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
