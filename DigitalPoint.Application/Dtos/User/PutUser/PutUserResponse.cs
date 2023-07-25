namespace DigitalPoint.Application.Dtos.User.PutUser
{
    public class PutUserResponse
    {
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public PutUserResponse(bool success = true) : this() => Success = success;

        public PutUserResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);
    }
};
