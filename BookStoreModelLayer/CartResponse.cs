using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer
{
    public class CartResponse
    {
        public int CartId { get; set; }
        public int BookQuantity { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public string BookAutherName { get; set; }
        public int BookPrice { get; set; }
        public string BookImage { get; set; }
    }
}
