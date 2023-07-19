using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints;
using DigitalPoint.Application.Interfaces.WorkPoints.cs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalPointBackEnd.Controllers
{
    public class WorkPointsController : ControllerBase
    {
        private IWorkPointService _workPointService;

        public WorkPointsController(IWorkPointService workPointService)
        {
            _workPointService = workPointService;
        }

        [Authorize]
        [HttpPost("/insert-work-point")]
        public async Task<ActionResult<InsertWorkPointResponse>> insertWorkPoint([FromBody]InsertWorkPointRequest insertWorkPoint)
        {
            var id = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            var result = await _workPointService.InsertWorkPoint(insertWorkPoint,id);

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
};
