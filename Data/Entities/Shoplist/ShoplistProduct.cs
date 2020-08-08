using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Shoplist
{
    public class ShoplistProduct : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
