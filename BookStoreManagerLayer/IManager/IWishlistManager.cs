using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IWishlistManager
    {
        Wishlist AddWishlist(Wishlist wishlist);
        int DeleteWishlist(int userId, int bookId);
        List<WishlistResponse> GetAllWishlist(int userId);
    }
}
