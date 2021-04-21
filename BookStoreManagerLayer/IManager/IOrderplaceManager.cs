using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface IOrderplaceManager
    {
        PlaceOrder OrderPlaced(PlaceOrder placeOrder);
        List<PlaceOrderResponse> GetOrderPlace(int userId);
    }
}
