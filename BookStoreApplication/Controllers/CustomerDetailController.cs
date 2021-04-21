using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "User")]
    public class CustomerDetailController : ControllerBase
    {
        private readonly ICustomerDetailManager customerDetailManager;
        public CustomerDetailController(ICustomerDetailManager customerDetailManager)
        {
            this.customerDetailManager = customerDetailManager;
        }

        [HttpPost]
        public IActionResult AddCustomerDetail(CustomerDetail detail)
        {
            try
            {
                var userId = TokenUserId();
                detail.UserId = userId;
                var result = this.customerDetailManager.AddCustomerDetail(detail);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Customer Detail Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to add Customer detail" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCustomerDetail(CustomerDetail detail)
        {
            try
            {
                var userId = TokenUserId();
                detail.UserId = userId;
                var result = this.customerDetailManager.UpdateCustomerDetail(detail);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Customer Detail Updated Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to Update Customer detail" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllCustomerDetail()
        {
            try
            {
                var userId = TokenUserId();
                var result = this.customerDetailManager.GetAllCustomerDetail(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Get all Customer Detail Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to get Customer detail" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }

        }

        private int TokenUserId()
        {
            return Convert.ToInt32(User.FindFirst("UserId").Value);
        }
    }
}