

using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint
{
    public class InsertWorkPointResponse
    {
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public InsertWorkPointResponse(bool success = true) : this() => Success = success;

        public InsertWorkPointResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
}
