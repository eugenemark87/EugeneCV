using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string AwardDescription { get; set; }
    }
}
