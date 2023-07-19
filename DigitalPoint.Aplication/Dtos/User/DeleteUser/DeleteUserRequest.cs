using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.DeleteUser 
{
    public class DeleteUserRequest
    {
        [Required(ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "")]

        public string Email { get; set; }

    }
};

