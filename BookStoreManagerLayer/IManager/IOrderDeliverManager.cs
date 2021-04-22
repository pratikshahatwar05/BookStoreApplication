using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IOrderDeliverManager
    {
        OrderDelivered OrderDeliver(OrderDelivered orderDelivered);
        OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered);
        int DeleteDeliveryStatus(int orderId);
    }
}
