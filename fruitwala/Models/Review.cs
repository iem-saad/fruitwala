using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fruitwala.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [StringLength(2048, MinimumLength = 2, ErrorMessage = "The minimal length is 2 characters, maximum length is 2048 characters")]
         public string FruitReview { get; set; }
        
        public string UserId { get; set; }
       // [Required]
        [Display(Name = "Food")]
        public int FoodId { get; set;}
        //[ForeignKey("FoodId")]

        // public FoodTypes FoodTypes { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]

        public DateTime Date { get; set; }

        //public virtual Foods Foods{ get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
