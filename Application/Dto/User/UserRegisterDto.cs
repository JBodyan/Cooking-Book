﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.User
{
    public class UserRegisterDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }

    }
}
