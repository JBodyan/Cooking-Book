using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class ProductCategory : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
