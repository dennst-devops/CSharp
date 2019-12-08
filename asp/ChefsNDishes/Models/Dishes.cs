using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }

        [Required (ErrorMessage = "You must enter a dish name")]
        [Display(Name = "Dish Name:")] 
        [MinLength(4, ErrorMessage = "The dish name must be at least 4 chars")]
        public string Name { get; set; }

        [Required (ErrorMessage = "You must select a number between 1 and 5 for taste")]
        [Display(Name = "Tastiness:")] 
        [Range(1,5)]
        public int Tastiness { get; set; }

        [Required (ErrorMessage = "You must enter a number greater that one for calories")]
        [Display(Name = "Calories:")] 
        [Range(1,32000, ErrorMessage = "Please enter a number greater than 1")]
        public int Calories { get; set; }

        [Required (ErrorMessage = "You must enter a description")]
        [Display(Name = "Description:")] 
        [MinLength(10, ErrorMessage = "The description must be at least 10 chars")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int ChefId { get; set; }

        // [Required (ErrorMessage = "You must enter a chef")]
        // [Display(Name = "Creating Chef:")] 
        public Chef Creator { get; set; }
    }
}