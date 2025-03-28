namespace EugeneCV.Models
{
    public class CVViewModel
    {
        public Profile profile { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<SkillCategory> SkillCategories { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Award> Awards { get; set; }
        public IEnumerable<Professional> Professionals { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        public IEnumerable<Screenshot> Screenshots { get; set; }

    }
}
