using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public string Duration { get; set; }

    }
}
