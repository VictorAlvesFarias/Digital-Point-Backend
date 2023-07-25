using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint
{
    public class PutWorkPointRequest
    {
        public int Id { get; set; }
        public DateTime Day { get;  set; }
        public string DepartureTime { get;  set; }
        public string EntryTime { get;  set; }

        public bool Attendance { get; set; }

    }
}
