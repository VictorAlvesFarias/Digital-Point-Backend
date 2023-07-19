using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints;
using DigitalPoint.Application.Interfaces.WorkPoints.cs;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DigitalPoint.Domain.Services
{
    public class WorkPointsService : IWorkPointService
    {
        
        private readonly DbSet<WorkPoint> _workPoints;
        private readonly DigitalPointContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WorkPointsService(DigitalPointContext context, UserManager<IdentityUser> userManager)
        {
            _workPoints = context.Set<WorkPoint>();
            _context = context;
            _userManager = userManager;
        }
        

        public Task<DeleteWorkPointResponse> DeleteWorkPoint(DeleteWorkPointRequest deleteWorkPoint)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllWorkPointResponse> GetAllWorkPoints()
        {
            throw new NotImplementedException();
        }

        public async  Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest insertWorkPoint, string id)
        {
            var User = await _userManager.FindByIdAsync(id);

            await _workPoints.AddAsync(WorkPoint.Create(
                day: DateTime.Now,
                departureTime: insertWorkPoint.DepartureTime,
                entryTime: insertWorkPoint.EntryTime,
                attendance: true,
                user: User
             ));

            await _context.SaveChangesAsync();

            var result = new InsertWorkPointResponse(true);

            return result;
        }

        public Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPoint)
        {
            throw new NotImplementedException();
        }
    }
}
