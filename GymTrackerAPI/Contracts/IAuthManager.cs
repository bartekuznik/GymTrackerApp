using GymTrackerAPI.Models.User;
using Microsoft.AspNetCore.Identity;

namespace GymTrackerAPI.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserRegisterDto userRegisterDto);
        Task<AuthResponseDto> Login(UserLoginDto userLoginDto);
    }
}
