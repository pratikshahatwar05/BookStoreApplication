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
    [Authorize(Roles = "User")]
    public class OrderPlaceController : ControllerBase
    {
        private readonly IOrderplaceManager orderplaceManager;

        public OrderPlaceController(IOrderplaceManager orderplaceManager)
        {
            this.orderplaceManager = orderplaceManager;
        }

        [HttpGet]
        public IActionResult GetOrderPlace()
        {
            try
            {
                var userId = TokenUserId();
                var result = this.orderplaceManager.GetOrderPlace(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Order place Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to place order" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult OrderPlaced(PlaceOrder placeOrder)
        {
            try
            {
                var userId = TokenUserId();
                placeOrder.UserId = userId;
                var result = this.orderplaceManager.OrderPlaced(placeOrder);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Order place Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to place order" });
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