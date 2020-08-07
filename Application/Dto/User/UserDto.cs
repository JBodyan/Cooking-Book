using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Application.Dto.User
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredDate { get; set; }

        public Role Role { get; set; }

        public bool IsEmailConfirmed { get; set; }
    }
}
