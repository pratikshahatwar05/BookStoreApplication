using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IOrderDeliveredRepo
    {
        OrderDelivered OrderDeliver(OrderDelivered orderDelivered);
        OrderDelivered UpdateDeliveryStatus(OrderDelivered orderDelivered);
        int DeleteDeliveryStatus(int orderId);
    }
}
