using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Models.User
{
    public class CreateUserDto : BaseUserDto
    {
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } // Przesyłamy czyste hasło, serwer je zahashuje
    }
}