using DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints;
using DigitalPoint.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPoint.Application.Interfaces.WorkPoints.cs
{
    public interface IWorkPointService
    {
        Task<InsertWorkPointResponse> InsertWorkPoint(InsertWorkPointRequest insertWorkPoint, string id);
        Task<DeleteWorkPointResponse> DeleteWorkPoint(DeleteWorkPointRequest deleteWorkPoint);
        Task<PutWorkPointResponse> PutWorkPoint(PutWorkPointRequest putWorkPoint);
        Task<GetAllWorkPointResponse> GetAllWorkPoints();
    }
}
