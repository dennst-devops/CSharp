using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginAndReg.Models
{
    public class LoginUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "You must enter a valid email address")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        [Display(Name = "Password:")]
        [MinLength(8, ErrorMessage = "Your password name must be at least 8 chars")]
        public string Password { get; set; }
    }
}