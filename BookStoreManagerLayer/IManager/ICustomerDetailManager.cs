using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.IManager
{
    public interface ICustomerDetailManager
    {
        CustomerDetail AddCustomerDetail(CustomerDetail detail);
        CustomerDetail UpdateCustomerDetail(CustomerDetail detail);
        List<CustomerDetail> GetAllCustomerDetail(int userId);
    }
}
