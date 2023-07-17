
using DigitalPoint.Application.Dtos.DeleteUser;
using DigitalPoint.Application.Dtos.InsertUser;
using DigitalPoint.Application.Dtos.LoginUser;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DigitalPoint.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<InsertUserResponse> InsertUser(InsertUserRequest insertUser);

        Task<LoginUserResponse> LoginUser(LoginUserRequest loginUser);

        Task<DeleteUserResponse> DeleteUser(DeleteUserRequest deleteUser);

        Task<string> CreateToken(IEnumerable<Claim> tokenClaims);


        Task<IList<Claim>> GetClaimsAndRoles(IdentityUser user);
    }
}
