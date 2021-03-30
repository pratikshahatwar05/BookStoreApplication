using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IUserManager
    {
        Users RegisterUser(Users user);
        List<Users> GetAllUsers();
    }
}
