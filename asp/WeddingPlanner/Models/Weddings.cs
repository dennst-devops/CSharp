using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "You must enter a name")]
        [Display(Name = "Wedder One:")]
        [MinLength(2, ErrorMessage = "The name must be at least 2 chars")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "You must enter a name")]
        [Display(Name = "Wedder Two:")]
        [MinLength(2, ErrorMessage = "The name must be at least 2 chars")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "You must enter an address")]
        [Display(Name = "Address:")]
        [MinLength(2, ErrorMessage = "The address must be at least 2 chars")]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You must enter a wedding date")]
        [PastDateValidation]
        [Display(Name = "Wedding date:")]
        public DateTime WeddingDate { get; set; }
        public class PastDateValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((DateTime)value < DateTime.Now)
                {
                    return new ValidationResult("Wedding date must be in the future");
                }
                return ValidationResult.Success;
            }
        }

        // [Required(ErrorMessage = "You must enter a number greater than one")]
        // [Display(Name = "ZZZZZZZ:")]
        // [Range(1, int.MaxValue, ErrorMessage = "Please enter a number greater than 1")]
        // public int Calories { get; set; }

        ////////////////////////////////////////////////////////////////
        // this is the connector to Thing

        public List<Connector> Guests { get; set; }
        public int CreatedByID { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}