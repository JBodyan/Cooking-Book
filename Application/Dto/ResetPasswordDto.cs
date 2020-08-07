using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ResetPasswordDto
    {
        public string ConfirmationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
    }
}
