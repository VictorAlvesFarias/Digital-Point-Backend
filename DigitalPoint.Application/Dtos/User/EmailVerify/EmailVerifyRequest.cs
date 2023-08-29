using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPoint.Application.Dtos.User.EmailVerify
{
    public class EmailVerifyRequest
    {

        [EmailAddress(ErrorMessage = "Campo Inválido")]
        public string Email { get; set; }
    }
}
