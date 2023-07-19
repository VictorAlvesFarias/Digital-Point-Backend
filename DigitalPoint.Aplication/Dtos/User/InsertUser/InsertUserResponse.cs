namespace DigitalPoint.Application.Dtos.User.InsertUser { 
    public class InsertUserResponse
    {
        public bool Success { get; private set; }

        public List<string> Errors { get; private set; }

        public InsertUserResponse() => Errors = new List<string>();

        public InsertUserResponse(bool success = true) : this() => Success = success;

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);
    }
};
