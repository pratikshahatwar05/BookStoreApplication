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
    [Authorize]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistManager wishlistManager;
        public WishlistController(IWishlistManager wishlistManager)
        {
            this.wishlistManager = wishlistManager;
        }

        [HttpPost]
        public IActionResult AddWishlist(Wishlist wishlist)
        {
            try
            {
                var userId = TokenUserId();
                wishlist.UserId = userId;
                var result = this.wishlistManager.AddWishlist(wishlist);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Wishlist Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to add wishlist" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteWishlist(int bookId)
        {
            try
            {
                var userId = TokenUserId();
                var result = this.wishlistManager.DeleteWishlist(userId,bookId);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Wishlist deleted Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to delete wishlist" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllWishlist()
        {
            try
            {
                var userId = TokenUserId();
                var result = this.wishlistManager.GetAllWishlist(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Wishlist get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = true, Message = "Unable to get wishlist" });
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