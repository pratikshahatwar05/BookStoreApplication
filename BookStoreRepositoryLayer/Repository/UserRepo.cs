using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly IConfiguration configuration;
        public UserRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDbConnection");
            this.connection = new SqlConnection(this.connectionString);
        }
        public Users RegisterUser(Users user)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddUser", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        return user;
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

        public List<Users> GetAllUsers()
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("GetAllUsers",this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Users> user = new List<Users>();
                    Users users = new Users();
                    while (dataReader.Read())
                    {
                        if (dataReader != null)
                        {
                            users.UserId = (int)dataReader["UserId"];
                            users.Name = dataReader["Name"].ToString();
                            users.Email = dataReader["Email"].ToString();
                            users.Password = dataReader["Password"].ToString();
                            user.Add(users);
                            break;
                        }
                    }
                    return user;
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
