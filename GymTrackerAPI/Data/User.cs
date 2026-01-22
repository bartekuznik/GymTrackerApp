using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GymTrackerAPI.Data
{
    public class User : IdentityUser<Guid> //zmiana ID ze string na GUID
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        [Range(50, 250)]
        public short? Height { get; set; }
    }
}


//używam IdentityUser żeby potem dodac jwt