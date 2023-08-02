using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.InsertUser
{
    public class InsertUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Campo é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "O campo  deve ter entre 1 e 50 caracteres", MinimumLength = 1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
        public string PasswordConfirm { get; set; }
    }
};



