using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint
{
    public class InsertWorkPointRequest
    {
        public string DepartureTime { get; set; }
        public string EntryTime { get; set; }

    }
}
