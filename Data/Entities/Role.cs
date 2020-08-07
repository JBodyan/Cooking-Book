using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
