using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fruitwala.Models
{
    public class FoodTypes
    {
        public int Id { get; set; }
        [Required]
        [Display (Name ="Food Type")]

        public string FoodType { get; set; }
    }
}
