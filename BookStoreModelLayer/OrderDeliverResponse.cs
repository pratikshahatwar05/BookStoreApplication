using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer
{
    public class OrderDeliverResponse
    {
        public int OrderDeliverId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAutherName { get; set; }
        public int BookPrice { get; set; }
        public string BookImage { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
