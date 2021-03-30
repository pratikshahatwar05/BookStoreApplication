using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICartRepo
    {
        Cart AddCart(Cart cart);
        Cart UpdateCart(Cart cart);
        Cart DeleteCart(Cart cart);
    }
}
