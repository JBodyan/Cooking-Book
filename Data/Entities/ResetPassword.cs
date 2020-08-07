using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ResetPassword : IBaseEntity
    {
        public Guid Id { get; set; }
        public string ConfirmationNumber { get; set; }
        public DateTime ResetDate { get; set; }
    }
}
