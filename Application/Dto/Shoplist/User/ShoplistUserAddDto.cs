using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Shoplist.User
{
    public class ShoplistUserAddDto
    {
        public Guid Id { get; set; }
        public int ShoplistRoleId { get; set; }
        public Guid UserId { get; set; }
        public Guid ShoplistId { get; set; }
    }
}
