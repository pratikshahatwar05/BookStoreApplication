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
    public class OrderplaceRepo : IOrderplaceRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public OrderplaceRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public List<PlaceOrderResponse> GetOrderPlace(int userId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetPlaceOrder", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    List<PlaceOrderResponse> placeorderRsponse = new List<PlaceOrderResponse>();
                    PlaceOrderResponse placeorder = new PlaceOrderResponse();
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            placeorder.OrderId = (int)dataReader["OrderId"];
                            placeorder.BookId = (int)dataReader["BookId"];
                            placeorder.BookName = dataReader["BookName"].ToString();
                            placeorder.BookAutherName = dataReader["BookAutherName"].ToString();
                            placeorder.BookPrice = (int)dataReader["BookPrice"];
                            placeorder.BookImage = dataReader["BookImage"].ToString();
                            placeorder.CustomerId = (int)dataReader["CustomerId"];
                            placeorder.Name = dataReader["Name"].ToString();
                            placeorder.PhoneNumber = dataReader["PhoneNumber"].ToString();
                            placeorder.Address = dataReader["Address"].ToString();
                            placeorder.City = dataReader["City"].ToString();
                            placeorderRsponse.Add(placeorder);
                            break;
                        }
                    }
                    return placeorderRsponse;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public PlaceOrder OrderPlaced(PlaceOrder placeOrder)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spOderPlace", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserId", placeOrder.UserId);
                    command.Parameters.AddWithValue("CustomerId", placeOrder.CustomerId);
                    command.Parameters.AddWithValue("BookId", placeOrder.BookId);
                    command.Connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return placeOrder;
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
    }
}
