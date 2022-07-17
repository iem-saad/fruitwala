using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fruitwala.Models
{
    public class Order
    {
        public int Id { get; set; }

        public float TotalPrice { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // Navigation property
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
