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
    [Authorize (Roles ="User")]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;

        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }

        [HttpPost]
        public IActionResult AddCart(Cart cart)
        {
            try
            {
                var result = this.cartManager.AddCart(cart);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to add Cart" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpDelete("{cartId}")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                var userId = TokenUserId();
                var result = this.cartManager.DeleteCart(cartId,userId);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Cart Deleted Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to delete Cart" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllCart()
        {
            try
            {
                var userId = TokenUserId();
                var result = this.cartManager.GetAllCart(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to get Cart" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCart(Cart cart)
        {
            try
            {
                int userId = TokenUserId();
                cart.UserId = userId;
                var result = this.cartManager.UpdateCart(cart);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart updated Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to update Cart" });
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