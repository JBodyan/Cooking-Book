using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Product : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }
    }
}
