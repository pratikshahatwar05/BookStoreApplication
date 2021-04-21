using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer.Manager
{
    public class CustomerDetailManager : ICustomerDetailManager
    {
        private readonly ICustomerDetailRepo customerDetail;
        public CustomerDetailManager(ICustomerDetailRepo customerDetail)
        {
            this.customerDetail = customerDetail;
        }
        public CustomerDetail AddCustomerDetail(CustomerDetail detail)
        {
            try
            {
                return this.customerDetail.AddCustomerDetail(detail);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CustomerDetail> GetAllCustomerDetail(int userId)
        {
            try
            {
                return this.customerDetail.GetAllCustomerDetail(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public CustomerDetail UpdateCustomerDetail(CustomerDetail detail)
        {
            try
            {
                return this.customerDetail.UpdateCustomerDetail(detail);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
