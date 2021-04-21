using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class OrderplaceManager : IOrderplaceManager
    {
        private readonly IOrderplaceRepo orderplaceRepo;
        public OrderplaceManager(IOrderplaceRepo orderplaceRepo)
        {
            this.orderplaceRepo = orderplaceRepo;
        }
        public List<PlaceOrderResponse> GetOrderPlace(int userId)
        {
            try
            {
                return this.orderplaceRepo.GetOrderPlace(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public PlaceOrder OrderPlaced(PlaceOrder placeOrder)
        {
            try
            {
                return this.orderplaceRepo.OrderPlaced(placeOrder);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
