using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramwork1.Entities
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }


    }
}
