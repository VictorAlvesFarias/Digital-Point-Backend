using DigitalPoint.Application.Dtos.Default;
using DigitalPoint.Application.Dtos.User.DeleteUser;
using DigitalPoint.Application.Dtos.User.EmailVerify;
using DigitalPoint.Application.Dtos.User.InsertUser;
using DigitalPoint.Application.Dtos.User.LoginUser;
using DigitalPoint.Application.Dtos.User.PutUser;
using DigitalPoint.Application.Dtos.User.PutUserPassword;
using DigitalPoint.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalPointBackEnd.Controllers
{

    public class UserController : ControllerBase
    {

        private IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IIdentityService Get_identityService()
        {
            return _identityService;
        }

        [HttpPost("/create-user")]
        public async Task<ActionResult<InsertUserResponse>> Create([FromBody] InsertUserRequest insertUser)
        {

            var result = await _identityService.InsertUser(insertUser);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/sign-user")]
        public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserRequest userLogin)
        {
 
            var result = await _identityService.LoginUser(userLogin);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize]
        [HttpDelete("/delete-current-user")]
        public async Task<ActionResult<DefaultResponse>> DeleteCurrentUser([FromBody] DeleteCurrentUserRequest deleteCurrentUserRequest)
        {
            var id = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            var result = await _identityService.DeleteUser(id, deleteCurrentUserRequest);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);

        }

        [Authorize]
        [HttpPut("/update-current-user")]
        public async Task<ActionResult<PutUserResponse>> PutCurrentUser([FromBody] PutUserRequest putUserRequest)
        {
            var id = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            var result = await _identityService.PutUser(putUserRequest, id);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [Authorize]
        [HttpPut("/update-current-user-password")]
        public async Task<ActionResult<PutUserResponse>> PutCurrentUserPassword([FromBody] PutUserPasswordRequest putUserPasswordRequest)
        {
            var id = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            var result = await _identityService.PutUserPassword(putUserPasswordRequest, id);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/verify-email")]
        public async Task<ActionResult<DefaultResponse>> VerifyEmail([FromBody] EmailVerifyRequest emailVerifyRequest)
        {
            var result = await _identityService.EmailVerify(emailVerifyRequest.Email);

            if (result.Success)
            {
                return Ok(result);
            }

            else if (result.Errors.Count > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
