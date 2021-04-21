using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class CustomerDetail
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("CustomerDetailType")]
        public int CustomerDetailTypeId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Pincode { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
    }
}
