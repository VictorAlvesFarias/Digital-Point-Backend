

using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Dtos.WorkPoints.DeleteWorkPoint
{
    public class DeleteWorkPointResponse
    {
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public DeleteWorkPointResponse(bool success = true) : this() => Success = success;

        public DeleteWorkPointResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
}
