using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [Display(Name = "First Name:")] 
        [MinLength(4, ErrorMessage = "First name must be at least 4 chars")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name:")] 
        [MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Age:")] 
        [Range(1,115)]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Email Address:")] 
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password:")] 
        [MinLength(8)]
        public string Password { get; set; }
    }
}