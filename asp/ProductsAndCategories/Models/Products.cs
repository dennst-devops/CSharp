using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "You must enter a Product name")]
        [Display(Name = "Name:")]
        [MinLength(2, ErrorMessage = "The Product name must be at least 2 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter a Description")]
        [Display(Name = "Description:")]
        [MinLength(2, ErrorMessage = "The Description name must be at least 2 chars")]
        public string Description { get; set; }

        [Display(Name = "Price:")]
        [Range(1,4000000000, ErrorMessage = "Please enter a price greater than 1")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
