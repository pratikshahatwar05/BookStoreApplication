using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
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
                var password = Encryptdata(user.Password);
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("AddUsers", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", password);
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

        public string LoginUser(LoginModel user)
        {
            try
            {
                using (this.connection)
                {
                    var password = Encryptdata(user.Password);
                    SqlCommand command = new SqlCommand("spLogin", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", password);
                    this.connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    Users users = new Users();
                    if(dataReader.HasRows)
                        while (dataReader.Read())
                        {
                            if (dataReader != null)
                            {
                                users.UserId = (int)dataReader["UserId"];
                                users.Name = dataReader["Name"].ToString();
                                users.Email = dataReader["Email"].ToString();
                                users.Password = dataReader["Password"].ToString();
                                break;
                            }
                        }
                    string token = GenrateJWTToken(users.UserId);
                    return token;
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

        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

         private string GenrateJWTToken(int userId)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, "User"),
                            new Claim("userId",userId.ToString())
                        };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}
