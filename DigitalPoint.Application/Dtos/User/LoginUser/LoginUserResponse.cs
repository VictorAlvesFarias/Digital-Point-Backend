namespace DigitalPoint.Application.Dtos.User.LoginUser 
{
    public class LoginUserResponse
    {
        public class Data
        {
            public string Name { get; set; }

            public string Token { get; set; }

            public string Email { get; set; }   
        }

        public Data User { get; set; }

        public bool Success { get; private set; }

        public List<string> Errors { get; private set; }

        public LoginUserResponse(bool success = true) : this() => Success = success;

        public LoginUserResponse() => Errors = new List<string>();

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public void AddError(string error) => Errors.Add(error);

    }
};
