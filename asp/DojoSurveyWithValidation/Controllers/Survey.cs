using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidation.Models
{
    public class Survey
    {
        [Required]
        [Display(Name = "Name:")] 
        [MinLength(2, ErrorMessage = "Name must be at least 2 chars")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Location:")] 
        [MinLength(1, ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Language:")] 
        [MinLength(1, ErrorMessage = "Language is required")]
        public string Language { get; set; }

        [MinLength(20, ErrorMessage = "Comment must be at least 20 chars")]
        public string Comment { get; set; }
    }

}