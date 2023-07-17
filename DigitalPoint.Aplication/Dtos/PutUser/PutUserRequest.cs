using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalPoint.Application.Dtos.PutUser
{
    public class PutUserRequest {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

    }
}
