using System;
using System.Collections.Generic;
using Application.Dto.Shoplist.Category;
using Application.Dto.Shoplist.User;

namespace Application.Dto.Shoplist
{
    public class ShoplistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public virtual List<ShoplistUserDto> Users { get; set; }
        public virtual List<ShoplistCategoryDto> Categories { get; set; }
    }
}
