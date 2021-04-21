using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class OrderDelivered
    {
        [Key]
        public int OrderDeliverId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("CustomerDetails")]
        public int CustomerId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public bool IsDelivered { get; set; }
        public int OrderId { get; set; }
    }
}
