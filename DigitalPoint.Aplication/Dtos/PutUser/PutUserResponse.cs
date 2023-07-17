namespace DigitalPoint.Application.Dtos.PutUser
{
    public class PutUserResponse {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public List<string> Errors { get; set; }
        public bool Success { get; set; }
        public PutUserResponse(bool success = true) : this() => Success = success;
        public PutUserResponse() => Errors = new List<string>();
        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
        public void AddError(string error) => Errors.Add(error);
    }
}
