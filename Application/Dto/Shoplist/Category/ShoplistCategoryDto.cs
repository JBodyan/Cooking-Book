using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Shoplist.Product;

namespace Application.Dto.Shoplist.Category
{
    public class ShoplistCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ShoplistProductDto> Products { get; set; }
    }
}
