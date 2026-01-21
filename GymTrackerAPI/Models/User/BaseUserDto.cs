using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.User
{
    public abstract class BaseUserDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        [Range(50, 250)]
        public short? Height { get; set; }
    }
}