using System.ComponentModel.DataAnnotations;

namespace EugeneCV.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
}
