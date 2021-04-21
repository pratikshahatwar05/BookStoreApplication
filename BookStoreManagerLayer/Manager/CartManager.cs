using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepo cartRepo;
        public CartManager(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }
        public Cart AddCart(Cart cart)
        {
            try
            {
               return this.cartRepo.AddCart(cart);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteCart(int cartId, int userId)
        {
            try
            {
                return this.cartRepo.DeleteCart(cartId,userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CartResponse> GetAllCart(int userId)
        {
            try
            {
                return this.cartRepo.GetAllCart(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Cart UpdateCart(Cart cart)
        {
            try
            {
                return this.cartRepo.UpdateCart(cart);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
