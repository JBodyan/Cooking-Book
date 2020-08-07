using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.User
{
    public class UserTokenDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Role { get; set; }

        public TokenDto Token { get; set; }
    }
}
