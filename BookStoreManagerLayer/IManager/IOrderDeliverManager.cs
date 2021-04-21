using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IOrderDeliverManager
    {
        OrderDelivered OrderDeliver(OrderDelivered orderDelivered);
        List<OrderDeliverResponse> GetOrderDelivered(int userId);
        OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered);
        int DeleteDeliveryStatus(int orderId);
    }
}
