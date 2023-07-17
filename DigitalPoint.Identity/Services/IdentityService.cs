using DigitalPoint.Application.Dtos.DeleteUser;
using DigitalPoint.Application.Dtos.InsertUser;
using DigitalPoint.Application.Dtos.LoginUser;
using DigitalPoint.Application.Interfaces.Services;
using DigitalPoint.Identity.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DigitalPoint.Identity.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly SignInManager<IdentityUser> _singInManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly JwtOptions _jwtOptions;
        public IdentityService(SignInManager<IdentityUser> singInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions) {
            _singInManager = singInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<IList<Claim>> GetClaimsAndRoles(IdentityUser user) {

            var claims = await _userManager.GetClaimsAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));

            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));

            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            };

            return claims;

        }
        public async Task<string> CreateToken(IEnumerable<Claim> tokenClaims) {

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;

        }
        public async Task<InsertUserResponse> InsertUser(InsertUserRequest insertUser) {

            var identityUser = new IdentityUser {
                UserName = insertUser.Email,
                Email = insertUser.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(identityUser, insertUser.Password);

            var insertUserResponse = new InsertUserResponse(result.Succeeded);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(identityUser, false);
            }

            else if (!result.Succeeded && result.Errors.Count() > 0)
            {
                insertUserResponse.AddErrors(result.Errors.Select(r => r.Description));
            }


            return insertUserResponse;

        }
        public async Task<LoginUserResponse> LoginUser(LoginUserRequest loginUser) {

            var result = await _singInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);

            var loginUserResponse = new LoginUserResponse(result.Succeeded);

            if (result.Succeeded) {
                return await CreateCredentials(loginUser.Email);
            }

            else if (!result.Succeeded) {
                loginUserResponse.AddError("Fail Login");
            }

            else {
                loginUserResponse.AddError("Contatct the Administrator");
            };

            return loginUserResponse;

        }
        public async Task<LoginUserResponse> CreateCredentials(string Email) {

            var user = await _userManager.FindByNameAsync(Email);

            var claims = await GetClaimsAndRoles(user);

            var token = await CreateToken(claims);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);

            return new LoginUserResponse(
                 success: true,
                 token: token
             );
        }
        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest deleteUser) {
            try {
                var user = await _userManager.FindByEmailAsync(deleteUser.Email);

                if (user != null) {
                    var result = await _userManager.DeleteAsync(user);

                    var deleteUserResponse = new DeleteUserResponse(result.Succeeded);

                    if (result.Succeeded)
                    {
                        return deleteUserResponse;
                    }

                    else if (!result.Succeeded && result.Errors.Count() > 0)
                    {
                        deleteUserResponse.AddErrors(result.Errors.Select(r => r.Description));
                    }

                    return deleteUserResponse;
                }

                else
                {
                    var deleteUserResponse = new DeleteUserResponse(false);
                    deleteUserResponse.AddError("User is not find");
                    return deleteUserResponse;
                }

            }
            catch {
                var deleteUserResponse = new DeleteUserResponse(false);
                deleteUserResponse.AddError("Contact the Administrator");
                return deleteUserResponse;
            }

        }

    }
 }
