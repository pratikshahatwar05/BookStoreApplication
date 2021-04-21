using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public IActionResult Register(Users users)
        {
            try
            {
                var result = this.userManager.RegisterUser(users);
                if(result != null)
                {
                    return this.Ok(new { Status = true, Message = "User Registration Successful", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "User Registration Unsuccessful" });
            }
            catch(Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message});
            }
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = this.userManager.LoginUser(loginModel);
                if(result != null)
                {
                    return this.Ok(new { Status = true, Message = "User Login Successful", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "User Login Unsuccessful" });
            }
            catch(Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var result = this.userManager.GetAllUsers();
                if(result != null)
                {
                    return this.Ok(new { Status = true, Message = "All users data get successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to get users data" });
            }
            catch(Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}