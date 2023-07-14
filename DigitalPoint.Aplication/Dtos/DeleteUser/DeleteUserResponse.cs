namespace DigitalPoint.Application.Dtos.LoginUser
{
    public class DeleteUserResponse
    {
        public bool Success { get; private set; }

        public List<string> Errors { get; private set; }

        public DeleteUserResponse(bool success = true) : this() => Success = success;

        public DeleteUserResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }

}

