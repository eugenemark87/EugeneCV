namespace EugeneCV.Models
{
    public class SkillCategory
    {
        public int SkillCategoryId { get; set; }
        public string CategoryName { get; set; } 
        public string SubCategoryName { get; set; } 
        public ICollection<Skill> Skills { get; set; }
    }
}
