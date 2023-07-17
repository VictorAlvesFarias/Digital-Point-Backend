
using DigitalPoint.Application.Dtos.DeleteUser;
using DigitalPoint.Application.Dtos.InsertUser;
using DigitalPoint.Application.Dtos.LoginUser;
using DigitalPoint.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalPointBackEnd.Controllers
{

    public class UserController : ControllerBase
    {

        private IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
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
        [HttpDelete("/delete-users")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser([FromBody] DeleteUserRequest deleteUser)
        {

            var result = await _identityService.DeleteUser(deleteUser);

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
