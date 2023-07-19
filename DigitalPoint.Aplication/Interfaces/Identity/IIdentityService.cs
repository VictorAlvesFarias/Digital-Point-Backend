using DigitalPoint.Application.Dtos.User.DeleteUser;
using DigitalPoint.Application.Dtos.User.InsertUser;
using DigitalPoint.Application.Dtos.User.LoginUser;
using DigitalPoint.Application.Dtos.User.PutUser;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DigitalPoint.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<InsertUserResponse> InsertUser(InsertUserRequest insertUser);

        Task<LoginUserResponse> LoginUser(LoginUserRequest loginUser);

        Task<DeleteUserResponse> DeleteUser(DeleteUserRequest deleteUser);

        Task<string> CreateToken(IEnumerable<Claim> tokenClaims, DateTime expiration);

        Task<PutUserResponse> PutUser(PutUserRequest putUser, string Id);

        Task<IList<Claim>> GetClaimsAndRoles(IdentityUser user);
    }
}
