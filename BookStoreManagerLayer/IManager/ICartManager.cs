using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface ICartManager
    {
        Cart AddCart(Cart cart);
        Cart UpdateCart(Cart cart);
        int DeleteCart(int cartId, int userId);
        List<CartResponse> GetAllCart(int userId);
    }
}
