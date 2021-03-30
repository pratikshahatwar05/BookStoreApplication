using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public int BookQuantity { get; set; }
    }
}
