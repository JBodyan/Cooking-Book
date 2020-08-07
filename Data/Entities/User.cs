using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User : IBaseEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string RefreshToken { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public virtual Role Role { get; set; }
    }
}
