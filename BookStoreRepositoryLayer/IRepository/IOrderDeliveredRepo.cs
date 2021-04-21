using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IOrderDeliveredRepo
    {
        OrderDelivered OrderDeliver(OrderDelivered orderDelivered);
        List<OrderDeliverResponse> GetOrderDelivered(int userId);
        OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered);
        int DeleteDeliveryStatus(int orderId);
    }
}
