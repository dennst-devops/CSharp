using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required(ErrorMessage = "You must enter a first name")]
        [Display(Name = "First Name:")]
        [MinLength(2, ErrorMessage = "Your first name must be at least 2 chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name")]
        [Display(Name = "Last Name:")]
        [MinLength(2, ErrorMessage = "Your last name must be at least 2 chars")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a DOB")]
        [PastDateValidation]
        [Display(Name = "Date Of Birth:")]
        public DateTime DateOfBirth { get; set; }
        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }

    public class PastDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value > DateTime.Now)
            {
                return new ValidationResult("Date of Birth must be in the past");
            }
            return ValidationResult.Success;
        }
    }
}