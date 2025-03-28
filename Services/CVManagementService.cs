using EugeneCV.Data;
using EugeneCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace EugeneCV.Services
{
    public class CVManagementService : ICVManagementService
    {
        private readonly ApplicationDbContext _dbContext;

        public CVManagementService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CVViewModel> GetCVAsync()
        {
            var viewModel = new CVViewModel
            {
                profile = await _dbContext.Profiles.FirstOrDefaultAsync(),
                Experiences = await _dbContext.Experiences
                                      .Include(e => e.Descriptions)
                                      .ToListAsync(),
                Educations = await _dbContext.Educations.ToListAsync(),
                SkillCategories = await _dbContext.SkillCategories.ToListAsync(),
                Skills = await _dbContext.Skills.ToListAsync(),
                Awards = await _dbContext.Awards.ToListAsync(),
                Professionals = await _dbContext.Professionals.ToListAsync(),
                Hobbies = await _dbContext.Hobbies.ToListAsync(),
                Screenshots = await _dbContext.Screenshots.ToListAsync()
            };

            return viewModel;
        }


        public async Task<Profile?> GetProfileAsync()
        {
            await EnsureProfileExistsAsync();

            return await _dbContext.Profiles.FirstOrDefaultAsync();
        }

        public async Task EnsureProfileExistsAsync()
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync();

            if (profile == null)
            {
                // If profile doesn't exist, create a new one with default values
                profile = new Profile
                {
                    Name = "Your Name",
                    Address = "Your Address",
                    Email = "Your Emaill",
                    MobileNumber = "Your MobileNumber",
                    SpokenLanguage = "Your SpokenLanguage",
                    Nationality = "Your Nationality",
                    Availability = "Your Availabilty",
                    SkillsSummary = "Your SkillsSummary"
                };

                await _dbContext.Profiles.AddAsync(profile);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task UpdateProfileAsync(Profile profile)
        {
            // Ensure the profile exists before updating
            await EnsureProfileExistsAsync();

            // Update logic - assuming you have a DbContext for your database
            var existingProfile = await _dbContext.Profiles
                .FirstOrDefaultAsync(p => p.ProfileId == profile.ProfileId); // Assuming ProfileId is the key

            if (existingProfile == null)
            {
                throw new InvalidOperationException("Profile not found.");
            }

            // Update the fields - you can update any properties of the profile as needed
            existingProfile.Name = profile.Name;
            existingProfile.Email = profile.Email;
            existingProfile.Address = profile.Address;
            existingProfile.MobileNumber = profile.MobileNumber;
            existingProfile.SpokenLanguage = profile.SpokenLanguage;
            existingProfile.Nationality = profile.Nationality;
            existingProfile.Availability = profile.Availability;
            existingProfile.SkillsSummary = profile.SkillsSummary;
            // Update other fields similarly...

            // Save the changes to the database
            await _dbContext.SaveChangesAsync();
        }

        // Experience
        public async Task<IEnumerable<Experience>> GetExperienceListAsync()
        {
            return await _dbContext.Experiences.OrderBy(x => x.Priority).ToListAsync();
        }
        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            var experiences = await _dbContext.Experiences
                .FirstOrDefaultAsync(e => e.ExperienceId == id);
            if (experiences == null)
            {
                throw new InvalidOperationException("Experience not found.");
            }
            var descriptions = await _dbContext.ExperienceDescriptions.Where(e => e.ExperienceId == id).ToListAsync();
            experiences.Descriptions = descriptions;
            var screenshots = await _dbContext.Screenshots.Where(e => e.ExperienceId == id).ToListAsync();
            experiences.Screenshots = screenshots;
            return experiences;
        }
        public async Task AddExperienceAsync(Experience experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();

            if (experience.Descriptions != null)
            {
                foreach (var desc in experience.Descriptions)
                {
                    _dbContext.ExperienceDescriptions.Add(desc);
                }

                await _dbContext.SaveChangesAsync();  // Saves descriptions
            }
        }
        public async Task UpdateExperienceAsync(Experience experience)
        {
            _dbContext.Experiences.Update(experience);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteExperienceAsync(int id)
        {
            var employee = await _dbContext.Experiences.FindAsync(id);

            if (employee != null)
            {
                _dbContext.Experiences.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Skills
        public async Task<IEnumerable<SkillCategory>> GetSkillCategoryListAsync()
        {
            await Task.CompletedTask;
            return null; // Placeholder return value
        }
        public async Task AddSkillAsync(Skill skill)
        {
            await Task.CompletedTask;
        }
        public async Task UpdateSkillAsync(Skill skill)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteSkillAsync(int id)
        {
            await Task.CompletedTask;
        }

        // Education
        public async Task<IEnumerable<Education>> GetEducationListAsync()
        {
            await Task.CompletedTask;
            return null; // Placeholder return value
        }
        public async Task AddEducationAsync(Education education)
        {
            await Task.CompletedTask;
        }
        public async Task UpdateEducationAsync(Education education)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteEducationAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}
