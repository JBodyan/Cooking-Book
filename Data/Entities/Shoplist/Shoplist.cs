using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Shoplist
{
    public class Shoplist : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public virtual List<ShoplistUser> Users { get; set; }
        public virtual List<ShoplistCategory> Categories { get; set; }
    }
}
