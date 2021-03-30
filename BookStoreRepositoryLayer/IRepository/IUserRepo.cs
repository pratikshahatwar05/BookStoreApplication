using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IUserRepo
    {
        Users RegisterUser(Users user);
        List<Users> GetAllUsers();
    }
}
