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
    public class CustomerDetailRepo : ICustomerDetailRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;

        public CustomerDetailRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }

        public CustomerDetail AddCustomerDetail(CustomerDetail detail)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddCustomerDetail", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", detail.UserId);
                    command.Parameters.AddWithValue("@CustomerDetailsTypeId", detail.CustomerDetailTypeId);
                    command.Parameters.AddWithValue("@Name", detail.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", detail.PhoneNumber);
                    command.Parameters.AddWithValue("@Pincode", detail.Pincode);
                    command.Parameters.AddWithValue("@Locality", detail.Locality);
                    command.Parameters.AddWithValue("@Address", detail.Address);
                    command.Parameters.AddWithValue("@City", detail.City);
                    command.Parameters.AddWithValue("@Landmark", detail.Landmark);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return detail;
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

        public List<CustomerDetail> GetAllCustomerDetail(int userId)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spGetAllCustomerDetail", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    List<CustomerDetail> details = new List<CustomerDetail>();
                    CustomerDetail detail = new CustomerDetail();
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            detail.CustomerId = (int)dataReader["CustomerId"];
                            detail.UserId = (int)dataReader["UserId"];
                            detail.CustomerDetailTypeId = (int)dataReader["CustomerDetailTypeId"];
                            detail.Name = dataReader["Name"].ToString();
                            detail.PhoneNumber = dataReader["PhoneNumber"].ToString();
                            detail.Pincode = dataReader["Pincode"].ToString();
                            detail.Locality = dataReader["Locality"].ToString();
                            detail.Address = dataReader["Address"].ToString();
                            detail.City = dataReader["City"].ToString();
                            detail.Landmark = dataReader["Landmark"].ToString();
                            details.Add(detail);
                            break;
                        }
                    }
                    return details;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CustomerDetail UpdateCustomerDetail(CustomerDetail detail)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spUpdateCustomerDetail", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerId",detail.CustomerId);
                    command.Parameters.AddWithValue("@UserId", detail.UserId);
                    command.Parameters.AddWithValue("@CustomerDetailsTypeId", detail.CustomerDetailTypeId);
                    command.Parameters.AddWithValue("@Name", detail.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", detail.PhoneNumber);
                    command.Parameters.AddWithValue("@Pincode", detail.Pincode);
                    command.Parameters.AddWithValue("@Locality", detail.Locality);
                    command.Parameters.AddWithValue("@Address", detail.Address);
                    command.Parameters.AddWithValue("@City", detail.City);
                    command.Parameters.AddWithValue("@Landmark", detail.Landmark);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return detail;
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
