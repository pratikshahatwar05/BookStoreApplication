using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class WishlistManager : IWishlistManager
    {
        private readonly IWishlistRepo wishlistRepo;
        public WishlistManager(IWishlistRepo wishlistRepo)
        {
            this.wishlistRepo = wishlistRepo;
        }
        public Wishlist AddWishlist(Wishlist wishlist)
        {
            try
            {
                return this.wishlistRepo.AddWishlist(wishlist);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteWishlist(int userId, int bookId)
        {
            try
            {
                return this.wishlistRepo.DeleteWishlist(userId,bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<WishlistResponse> GetAllWishlist(int userId)
        {
            try
            {
                return this.wishlistRepo.GetAllWishlist(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
