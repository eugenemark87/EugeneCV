using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } 
        public int SkillCategoryId { get; set; } 
        public SkillCategory SkillCategory { get; set; }
    }
}
