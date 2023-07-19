

using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoints
{
    public class InsertWorkPointResponse
    {
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public InsertWorkPointResponse(bool success = true) : this() => Success = success;

        public InsertWorkPointResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

        public DateTime Day { get; private set; }
        public string DepartureTime { get; private set; }
        public string EntryTime { get; private set; }
        public bool Attendance { get; private set; } 
    }
}
