using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Product.Details
{
    public class ProductDetailsUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ProductId { get; set; }
    }
}
