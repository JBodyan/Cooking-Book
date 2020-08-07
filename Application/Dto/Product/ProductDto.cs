using System;
using System.Collections.Generic;
using System.Text;
using Application.Dto.Product.Category;

namespace Application.Dto.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual ProductCategoryDto Category { get; set; }
    }
}
