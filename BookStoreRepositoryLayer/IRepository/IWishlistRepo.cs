using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IWishlistRepo
    {
        Wishlist AddWishlist(Wishlist wishlist);
        int DeleteWishlist(int userId, int bookId);
        List<WishlistResponse> GetAllWishlist(int userId);
    }
}
