using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{

    public class RefreshToken : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }

}
