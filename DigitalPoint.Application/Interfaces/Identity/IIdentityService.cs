using DigitalPoint.Application.Dtos.Default;
using DigitalPoint.Application.Dtos.User.DeleteUser;
using DigitalPoint.Application.Dtos.User.InsertUser;
using DigitalPoint.Application.Dtos.User.LoginUser;
using DigitalPoint.Application.Dtos.User.PutUser;
using DigitalPoint.Application.Dtos.User.PutUserPassword;
using DigitalPoint.Domain.Entities;
using System.Security.Claims;

namespace DigitalPoint.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<InsertUserResponse> InsertUser(InsertUserRequest insertUser);

        Task<LoginUserResponse> LoginUser(LoginUserRequest loginUser);

        Task<DefaultResponse> DeleteUser(string id, DeleteCurrentUserRequest deleteCurrentUserRequest);

        Task<string> CreateToken(IEnumerable<Claim> tokenClaims, DateTime expiration);

        Task<PutUserResponse> PutUser(PutUserRequest putUser, string Id);

        Task<IList<Claim>> GetClaimsAndRoles(ApplicationUser user);

        Task<DefaultResponse> PutUserPassword(PutUserPasswordRequest putUser, string Id);

        Task<DefaultResponse> EmailVerify(string email);

        Task<ApplicationUser?> FindByIdAsync(string id);

    }
}
