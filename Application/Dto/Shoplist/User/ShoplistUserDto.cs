using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.User;

namespace Application.Dto.Shoplist.User
{
    public class ShoplistUserDto
    {
        public Guid Id { get; set; }
        public int ShoplistRoleId { get; set; }
        public Guid UserId { get; set; }
        public virtual UserDto User { get; set; }
        public Guid ShoplistId { get; set; }
        public virtual ShoplistDto Shoplist { get; set; }
    }
}
