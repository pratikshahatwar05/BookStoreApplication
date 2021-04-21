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
    public class OrderDeliveredController : ControllerBase
    {
        private readonly IOrderDeliverManager orderDeliverManager;

        public OrderDeliveredController(IOrderDeliverManager orderDeliverManager)
        {
            this.orderDeliverManager = orderDeliverManager;
        }

        [HttpGet]
        public IActionResult GetOrderDelivered()
        {
            try
            {
                var userId = TokenUserId();
                var result = this.orderDeliverManager.GetOrderDelivered(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Order delivered Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to delivered order" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult OrderDeliver(OrderDelivered orderDelivered)
        {
            try
            {
                var userId = TokenUserId();
                orderDelivered.UserId = userId;
                var result = this.orderDeliverManager.OrderDeliver(orderDelivered);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Order delivered add Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to delivered add order" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteDeliveryStatus(int orderId)
        {
            try
            {
                var userId = TokenUserId();
                var result = this.orderDeliverManager.DeleteDeliveryStatus(orderId);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Delete Delivery Status", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable Delete Delivery Status" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateDeliveryStatus(OrderDelivered orderDelivered)
        {
            try
            {
                var userId = TokenUserId();
                orderDelivered.UserId = userId;
                var result = this.orderDeliverManager.UpdateDeliveryStatus(orderDelivered);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Update Delivery Status", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable Update Delivery Status" });
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