namespace DigitalPoint.Application.Dtos.User.LoginUser 
{
    public class LoginUserResponse
    {
        public bool Success { get; private set; }

        public string Token { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public List<string> Errors { get; private set; }

        public LoginUserResponse(bool success = true) : this() => Success = success;

        public LoginUserResponse(bool success, string token) : this(success)
        {
            Token = token;
        }

        public LoginUserResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
};
