

using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints
{
    public class PutWorkPointResponse
    {
        public DateTime Day { get; private set; }
        public int DepartureTime { get; private set; }
        public int EntryTime { get; private set; }
        public bool Attendance { get; private set; }
        public ApplicationUser ApplicationUserId { get; private set; }

    }
}
