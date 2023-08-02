

using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.GetAllWorkPoints
{
    public class GetAllWorkPointResponse
    {
        public class WorkPoints
        {
            public int Id { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime EntryTime { get; set; }
        }

        public IEnumerable<WorkPoints> WorkPointsList { get; set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public GetAllWorkPointResponse(bool success = true) : this() => Success = success;
        public GetAllWorkPointResponse() => Errors = new List<string>();

    }
}
