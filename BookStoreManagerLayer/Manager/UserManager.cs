using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo userRepo;
        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        public List<Users> GetAllUsers()
        {
            try
            {
                return this.userRepo.GetAllUsers();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Users RegisterUser(Users user)
        {
            try
            {
                return this.userRepo.RegisterUser(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
