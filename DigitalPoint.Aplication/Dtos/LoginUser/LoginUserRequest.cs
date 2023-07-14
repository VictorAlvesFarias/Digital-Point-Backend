using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.LoginUser
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "")]

        public string Email { get; set; }

        [Required(ErrorMessage = "")]

        public string Password { get; set; }

    }
}
