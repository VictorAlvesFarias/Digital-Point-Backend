using DigitalPoint.Application.Dtos.User.PutUser;
using DigitalPoint.Application.Dtos.WorkPoints.DeleteWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints;
using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint;
using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;

namespace DigitalPoint.Domain.Services
{
    public class WorkPointService : IWorkPointService
    {
        private readonly IWorkPointRepository _workPointRepository;

        private readonly IBaseRepository<WorkPoint> _baseRepository;

        private readonly WorkPoint _wordPoint;

        private readonly UserManager<ApplicationUser> _userManager;

        public WorkPointService
        ( 
            IWorkPointRepository workPointRepository,
            IBaseRepository<WorkPoint> baseRepository,
            UserManager<ApplicationUser> userManager
        )
        {
            _userManager = userManager;
            _baseRepository = baseRepository;
           _workPointRepository = workPointRepository;
        }
        public async Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPointRequest, string userId)
        {
            var item = await _baseRepository.GetAsync(putWorkPointRequest.Id);

            if (item.ApplicationUser.Id == userId)
            {
                item.Update(
                   day: putWorkPointRequest.Day,
                   attendance: putWorkPointRequest.Attendance,
                   entryTime: putWorkPointRequest.EntryTime,
                   departureTime: putWorkPointRequest.DepartureTime
               );

                _baseRepository.UpdateAsync(item);

                return new PutWorkPointResponse(true);
            }

            var result = new PutWorkPointResponse(false);

            result.AddError("Unauthorized");

            return result;
        }
        public async Task<DeleteWorkPointResponse> DeleteWorkPoint(DeleteWorkPointRequest deleteWorkPoint, string userId)
        {
            var item = await _baseRepository.GetAsync(deleteWorkPoint.Id);

            if(item.ApplicationUser.Id == userId)
            {
                _baseRepository.RemoveAsync(item);

                return new DeleteWorkPointResponse(true);
            }

            var result = new DeleteWorkPointResponse(false);

            result.AddError("Unauthorized");

            return result;
        }
        public async Task<GetAllWorkPointResponse> GetAllWorkPoints(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var workPointsList = await _workPointRepository.GetAllAsync(user);

            var result = new GetAllWorkPointResponse() 
            {
                Success = true,
                WorkPointsList = from list in workPointsList select new GetAllWorkPointResponse.WorkPoints()
                { 
                    Day=list.Day,
                    Id =list.Id,    
                    DepartureTime = list.DepartureTime, 
                    EntryTime = list.EntryTime
                }
            };

            return result;
        }
        public async Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest workPoint, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var item = WorkPoint.Create
            (
                departureTime: workPoint.DepartureTime,
                applicationUser: user,
                entryTime: workPoint.EntryTime,
                day: DateTime.Now,
                attendance: true
            );

            _baseRepository.AddAsync(item);

            return new InsertWorkPointResponse(true);
        }
    }
}
