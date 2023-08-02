using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.User.PutUser
{
    public class PutUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
    }
};
