using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Shoplist
{
    public class ShoplistRole : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
