using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Shoplist
{
    public class ShoplistUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
