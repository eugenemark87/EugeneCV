using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public  class Profile
    {
        public int ProfileId { get; set; }

        [Display(Name = "Full Name")]
        // Ensure Name is required
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        // Ensure Address is required
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        // Ensure Email is required and in a valid email format
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        // Ensure Mobile Number is required and in a valid phone format
        [Required(ErrorMessage = "Mobile Number is required")]
        public string MobileNumber { get; set; }

        [Display(Name = "Spoken Language")]
        // Ensure SpokenLanguage is required
        [Required(ErrorMessage = "Spoken Language is required")]
        public string SpokenLanguage { get; set; }

        [Display(Name = "Nationality")]
        // Ensure Nationality is required
        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        [Display(Name = "Availability")]
        // Ensure Availability is required
        [Required(ErrorMessage = "Availability is required")]
        public string Availability { get; set; }

        [Display(Name = "Skills Summary")]
        // Ensure SkillsSummary is required
        [Required(ErrorMessage = "Skills Summary is required")]
        public string SkillsSummary { get; set; }

        public string Summary { get; set; }


    }
}