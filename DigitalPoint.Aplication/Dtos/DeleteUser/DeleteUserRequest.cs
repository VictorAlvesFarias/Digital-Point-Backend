using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.LoginUser
{
    public class DeleteUserRequest
    {
        [Required(ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "")]

        public string Email { get; set; }

    }
}
