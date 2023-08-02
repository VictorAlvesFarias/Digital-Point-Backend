using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.LoginUser 
{

    public class LoginUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Inválido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Password { get; set; }

    }

};
