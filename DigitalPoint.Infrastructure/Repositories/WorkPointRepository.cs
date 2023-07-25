using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Application.Interfaces.WorkPoints;
using DigitalPoint.Domain.Entities;
using DigitalPoint.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalPoint.Infrastructure.Repositories
{
    public class WorkPointRepository:IWorkPointRepository
    {

        private readonly IBaseRepository<WorkPoint> _baseRepository;

        private readonly DbSet<WorkPoint> _workPoint;

        private readonly DigitalPointContext _context;

        public WorkPointRepository
        (
            DigitalPointContext digitalPointContext, 
            IBaseRepository<WorkPoint> baseRepository
        )
        {
            _context = digitalPointContext;
            _workPoint = _context.Set<WorkPoint>();
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<WorkPoint>> GetAllAsync(ApplicationUser user)
        {
            var result = _workPoint.Where(item => item.ApplicationUser.Id == user.Id);

            return result;
        }

    }
}
