namespace DigitalPoint.Application.Dtos.Default
{
    public class DefaultResponse
    {
        public bool Success { get; set; }

        public List<string> Errors { get; set; }

        public DefaultResponse(bool success = true) : this() => Success = success;

        public DefaultResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);
    }
};