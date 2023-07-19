using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints
{
    public class DeleteWorkPointRequest
    {
        public DateTime Day { get; private set; }
        public int DepartureTime { get; private set; }
        public int EntryTime { get; private set; }

    }
}
