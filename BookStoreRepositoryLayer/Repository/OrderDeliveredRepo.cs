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
    public class OrderDeliveredRepo : IOrderDeliveredRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public OrderDeliveredRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateDeliveryStatus", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderDeliverId", orderDelivered.OrderDeliverId);
                    command.Parameters.AddWithValue("@UserId", orderDelivered.UserId);
                    command.Parameters.AddWithValue("@OrderId", orderDelivered.OrderId);
                    command.Parameters.AddWithValue("@IsDelivered", orderDelivered.IsDelivered);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return orderDelivered;
                    return null;
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

        public OrderDelivered OrderDeliver(OrderDelivered orderDelivered)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddOrderDelivered", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserId", orderDelivered.UserId);
                    command.Parameters.AddWithValue("CustomerId", orderDelivered.CustomerId);
                    command.Parameters.AddWithValue("BookId", orderDelivered.BookId);
                    command.Parameters.AddWithValue("IsDelivered", orderDelivered.IsDelivered);
                    command.Connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return orderDelivered;
                    return null;
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

        public int DeleteDeliveryStatus(int orderId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteCart", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    return orderId;
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
    }
}
