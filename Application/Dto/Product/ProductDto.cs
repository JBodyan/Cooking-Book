using System;
using System.Collections.Generic;
using System.Text;

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
