

using DigitalPoint.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DigitalPoint.Application.Dtos.WorkPoints.PutWorkPoint
{
    public class PutWorkPointResponse
    {
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public PutWorkPointResponse(bool success = true) : this() => Success = success;

        public PutWorkPointResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
}
