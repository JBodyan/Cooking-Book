using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Shoplist.Product
{
    public class ShoplistProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
