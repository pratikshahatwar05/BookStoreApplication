using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IUserManager
    {
        Users RegisterUser(Users user);
        string LoginUser(LoginModel user);
        List<Users> GetAllUsers();
    }
}
