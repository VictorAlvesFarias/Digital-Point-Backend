using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.PutUserPassword
{
    public class PutUserPasswordRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string NewPassword { get; set; }
    }
};
