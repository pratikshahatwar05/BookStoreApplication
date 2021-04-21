using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IOrderplaceRepo
    {
        PlaceOrder OrderPlaced(PlaceOrder placeOrder);
        List<PlaceOrderResponse> GetOrderPlace(int userId);
    }
}
