using DigitalPoint.Application.Dtos.WorkPoints.DeleteWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints;
using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalPointBackEnd.Controllers
{
    public class WorkPointsController : ControllerBase
    {
        private readonly IWorkPointService _workPointService;

        private readonly UserManager<ApplicationUser> _userManeger;

        public WorkPointsController
        (
            IWorkPointService workPointService, 
            UserManager<ApplicationUser> userManager
            
        )
        {
            _workPointService = workPointService;
            _userManeger = userManager;
        }

        [Authorize]
        [HttpPost("/create-work-point")]
        public async Task<ActionResult<InsertWorkPointResponse>> InsertWorkPoint([FromBody] InsertWorkPointRequest insertWorkPoint)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _workPointService.InsertWorkPoint(insertWorkPoint, userId);

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
        [HttpGet("/get-all-work-points")]
        public async Task<ActionResult<GetAllWorkPointResponse>> GetAllWorkPoints()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await  _workPointService.GetAllWorkPoints(userId);

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
        [HttpPut("/update-work-point")]
        public async Task<ActionResult<PutWorkPointResponse>> PutWorkPoint([FromBody] PutWorkPointRequest putWorkPointRequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _workPointService.PutWorkPoint(putWorkPointRequest, userId);

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
        [HttpDelete("/delete-work-point")]
        public async Task<ActionResult<DeleteWorkPointResponse>> DeleteWorkPoint([FromBody] DeleteWorkPointRequest deleteWorkPointRequest)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _workPointService.DeleteWorkPoint(deleteWorkPointRequest, userId);

            if (result.Success)
            {
                return Ok(result);
            }

            else if(result.Errors.Count >0 )
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


    }
};
