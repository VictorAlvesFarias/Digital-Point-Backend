using DigitalPoint.Application.Dtos.WorkPoints.DeleteWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints;
using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint;
using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Interfaces.WorkPoints
{
    public interface IWorkPointService
    {
       Task<DeleteWorkPointResponse> DeleteWorkPoint(DeleteWorkPointRequest deleteWorkPoint, string userId);
       Task<GetAllWorkPointResponse> GetAllWorkPoints(string userId);
       Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest insertWorkPoint,string userId);
       Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPointRequest, string userId);
    }
}
