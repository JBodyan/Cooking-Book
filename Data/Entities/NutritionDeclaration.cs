using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class NutritionDeclaration : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid DetailsId { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
