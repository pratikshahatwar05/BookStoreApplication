using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICustomerDetailRepo
    {
        CustomerDetail AddCustomerDetail(CustomerDetail detail);
        CustomerDetail UpdateCustomerDetail(CustomerDetail detail);
        List<CustomerDetail> GetAllCustomerDetail(int userId);
    }
}
