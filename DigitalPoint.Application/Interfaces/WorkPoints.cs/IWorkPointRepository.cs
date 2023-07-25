using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Interfaces.WorkPoints
{
    public interface IWorkPointRepository
    {
        Task<IEnumerable<WorkPoint>> GetAllAsync(ApplicationUser user);

    }
}
