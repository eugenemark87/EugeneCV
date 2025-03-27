using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class ExperienceDescription
    {
        public int ExperienceDescriptionId { get; set; }
        public int ExperienceId { get; set; }  //foreign key to experience
        public string Description { get; set; }
        public Experience? Experience { get; set; }
    }
}
