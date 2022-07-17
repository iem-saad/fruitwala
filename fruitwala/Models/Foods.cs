using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fruitwala.Models
{
    public class Foods
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool isAvailable { get; set; }

        [Required]
        [Display(Name = "Food Type")]
        public int FoodTypeId  { get; set; }
        [ForeignKey("FoodTypeId")]

        public FoodTypes FoodTypes { get; set; }
    }
}
