using EugeneCV.Models;
using Microsoft.CodeAnalysis;

namespace EugeneCV.Services
{
    public interface ICVManagementService
    {
        //CV
        Task<CVViewModel> GetCVAsync();
        
        // Profile
        Task<Profile?> GetProfileAsync();
        Task EnsureProfileExistsAsync();
        Task UpdateProfileAsync(Profile profile);

        // Experience
        Task<IEnumerable<Experience>> GetExperienceListAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task AddExperienceAsync(Experience experience);
        Task UpdateExperienceAsync(Experience experience);
        Task DeleteExperienceAsync(int id);

        // Skills
        Task<IEnumerable<SkillCategory>> GetSkillCategoryListAsync();
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(int id);

        // Education
        Task<IEnumerable<Education>> GetEducationListAsync();
        Task AddEducationAsync(Education education);
        Task UpdateEducationAsync(Education education);
        Task DeleteEducationAsync(int id);

    }
}
