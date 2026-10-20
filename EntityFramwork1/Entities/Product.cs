using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramwork1.Entities
{
    public class Product
    {
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
