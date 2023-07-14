using DigitalPoint.Application.Dtos.GetAllUsers;
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

        Task<GetAllUsersResponse> GetAllUsers();

        Task<LoginUserResponse> CreateToken(string email);

        Task<IList<Claim>> GetClaimsAndRoles(IdentityUser user);
    }
}
