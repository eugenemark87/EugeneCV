using EugeneCV.Models;
using Microsoft.EntityFrameworkCore;

namespace EugeneCV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ExperienceDescription> ExperienceDescriptions { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

    }
}
