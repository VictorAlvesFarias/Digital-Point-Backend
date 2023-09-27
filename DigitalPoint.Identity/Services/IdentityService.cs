using DigitalPoint.Identity.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using DigitalPoint.Application.Interfaces.Identity;
using DigitalPoint.Application.Dtos.User.InsertUser;
using DigitalPoint.Application.Dtos.User.LoginUser;
using DigitalPoint.Application.Dtos.User.PutUser;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Application.Dtos.Default;
using DigitalPoint.Application.Dtos.User.PutUserPassword;
using Microsoft.AspNetCore.Mvc;
using DigitalPoint.Application.Dtos.User.DeleteUser;
using System.Security.Policy;

namespace DigitalPoint.Identity.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly SignInManager<ApplicationUser> _singInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<ApplicationUser> singInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _singInManager = singInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<IList<Claim>> GetClaimsAndRoles(ApplicationUser user)
        {

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

        public async Task<string> CreateToken(IEnumerable<Claim> tokenClaims, DateTime expiration)
        {

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                expires: expiration,
                notBefore: DateTime.Now,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;

        }

        public async Task<InsertUserResponse> InsertUser(InsertUserRequest insertUser)
        {

            var applicationUser = new ApplicationUser
            {
                UserName = insertUser.Email,
                Email = insertUser.Email,
                EmailConfirmed = true,
                Name = insertUser.Name,
            };

            var result = await _userManager.CreateAsync(applicationUser, insertUser.Password);

            var insertUserResponse = new InsertUserResponse(result.Succeeded);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(applicationUser, false);
            }

            else if (!result.Succeeded && result.Errors.Count() > 0)
            {
                insertUserResponse.AddErrors(result.Errors.Select(r => r.Description));
            }

            return insertUserResponse;

        }

        public async Task<LoginUserResponse> LoginUser(LoginUserRequest loginUser)
        {

            var result = await _singInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, false);

            var loginUserResponse = new LoginUserResponse(result.Succeeded);

            if (result.Succeeded)
            {
                return await CreateCredentials(loginUser.Email);
            }

            else if (!result.Succeeded)
            {
                loginUserResponse.AddError("Senha ou Usuário inválido");
            }

            return loginUserResponse;

        }

        public async Task<LoginUserResponse> CreateCredentials(string Email)
        {

            var user = await _userManager.FindByNameAsync(Email);

            var claims = await GetClaimsAndRoles(user);

            var expiresDate = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);

            var token = await CreateToken(claims, expiresDate);

            var loginUserResponse = new LoginUserResponse(true);

            loginUserResponse.User = new LoginUserResponse.Data()
            {
                Name = user.Name,
                Email = user.Email,
                Token = token,
            };

            return loginUserResponse;
        }

        public async Task<DefaultResponse> DeleteUser(string id, [FromBody] DeleteCurrentUserRequest deleteCurrentUserRequest)
        {

            var user = await _userManager.FindByIdAsync(id);

            var login = await _singInManager.PasswordSignInAsync(user.Email, deleteCurrentUserRequest.Password, false, false);

            if (user != null)
            {

                var deleteUserResponse = new DefaultResponse();

                if (login.Succeeded)
                {
                    var result = await _userManager.DeleteAsync(user);

                    deleteUserResponse.Success = result.Succeeded;

                    if (result.Succeeded)
                    {
                        return deleteUserResponse;
                    }

                    else if (!result.Succeeded && result.Errors.Count() > 0)
                    {
                        deleteUserResponse.AddErrors(result.Errors.Select(r => r.Description));
                    }

                    deleteUserResponse.AddError("Houve algum erro interno");
                    return deleteUserResponse;
                }

                deleteUserResponse.Success = false;
                deleteUserResponse.AddError("Senha incorreta");
                return deleteUserResponse;

            }

            else
            {
                var deleteUserResponse = new DefaultResponse(false);
                deleteUserResponse.AddError("Usuário não encontrado");
                return deleteUserResponse;
            }
        }

        public async Task<PutUserResponse> PutUser(PutUserRequest putUser, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            user.UserName = putUser.Email == null ? putUser.Email : user.Email;
            user.Email = putUser.Email == null ? putUser.Email : user.Email;
            user.Name = putUser.UserName == null ? putUser.UserName : user.Name;

            var result = await _userManager.UpdateAsync(user);

            var putUserResponse = new PutUserResponse(result.Succeeded);

            if (result.Succeeded)
            {
                return new PutUserResponse
                {
                    Success = true,
                };
            }

            else if (!result.Succeeded)
            {
                putUserResponse.AddErrors(result.Errors.Select(r => r.Description));
            }

            return putUserResponse;
        }

        public async Task<DefaultResponse> EmailVerify(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);

            var result = new DefaultResponse(user == null ? true : false);

            if (user == null)
            {

                return result;

            }

            result.AddError("Email indisponivel");

            return result;
        }

        public async Task<DefaultResponse> PutUserPassword(PutUserPasswordRequest putUser, string Id)
        {

            var user = await _userManager.FindByIdAsync(Id);

            var login = await _singInManager.PasswordSignInAsync(user.Email, putUser.Password, false, false);

            var passwordHash = _userManager.PasswordHasher.HashPassword(user, putUser.Password);

            var newPassswordHash = _userManager.PasswordHasher.HashPassword(user, putUser.NewPassword);

            if (login.Succeeded == true)
            {

                user.PasswordHash = newPassswordHash;

                var result = await _userManager.UpdateAsync(user);

                var putUserPasswordResponse = new DefaultResponse(result.Succeeded);

                if (result.Succeeded)
                {
                    return putUserPasswordResponse;
                }

                else if (result.Errors.Count() > 0)
                {
                    putUserPasswordResponse.AddErrors(result.Errors.Select(r => r.Description));
                    return putUserPasswordResponse;
                }

                putUserPasswordResponse.AddError("Houve algum erro interno");
                return putUserPasswordResponse;


            }

            else
            {
                var putUserPasswordResponse = new DefaultResponse(false);

                putUserPasswordResponse.AddError("Senha incorreta");

                return putUserPasswordResponse;
            }

        }

        public async Task<ApplicationUser?> FindByIdAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            return user;
        }

    }
}
