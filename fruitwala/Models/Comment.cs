using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fruitwala.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]

        public string Description { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public FoodTypes FoodTypes { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }
    }
}
