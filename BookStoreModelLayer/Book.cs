using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreModelLayer
{
    public class Book
    {
        [Key] 
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAutherName { get; set; }
        public int BookPrice { get; set; }
        public string BookImage { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }
    }
}
