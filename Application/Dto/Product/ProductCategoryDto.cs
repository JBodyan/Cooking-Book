using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Product
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<ProductDto> Products { get; set; }
    }
}
