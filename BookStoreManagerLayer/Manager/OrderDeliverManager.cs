using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class OrderDeliverManager : IOrderDeliverManager
    {
        private readonly IOrderDeliveredRepo orderDeliveredRepo;

        public OrderDeliverManager(IOrderDeliveredRepo orderDeliveredRepo)
        {
            this.orderDeliveredRepo = orderDeliveredRepo;
        }

        public int DeleteDeliveryStatus(int orderId)
        {
            try
            {
                return this.orderDeliveredRepo.DeleteDeliveryStatus(orderId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public OrderDelivered OrderDeliver(OrderDelivered orderDelivered)
        {
            try
            {
                return this.orderDeliveredRepo.OrderDeliver(orderDelivered);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered)
        {
            try
            {
                return this.orderDeliveredRepo.UpdateDeliveryStatus(orderDelivered);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
