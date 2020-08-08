using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Shoplist
{
    public class ShoplistUser : IBaseEntity
    {
        public Guid Id { get; set; }
        public int ShoplistRoleId { get; set; }
        public virtual ShoplistRole Role { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ShoplistId { get; set; }
        public virtual Shoplist Shoplist { get; set; }
    }
}
