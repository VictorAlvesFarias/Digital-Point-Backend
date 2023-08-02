using DigitalPoint.Application.Dtos.Default;
using DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints;
using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint;
using DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint;
using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Interfaces.WorkPoints
{
    public interface IWorkPointService
    {
       Task<DefaultResponse> DeleteWorkPoint(int workPointId, string userId);
       Task<GetAllWorkPointResponse> GetAllWorkPoints(string userId);
       Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest insertWorkPoint,string userId );
       Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPointRequest, string userId, int workPointId);
    }
}
