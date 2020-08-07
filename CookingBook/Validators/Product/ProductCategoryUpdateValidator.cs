using Application.Dto.Product;
using FluentValidation;

namespace CookingBook.Validators.Product
{
    public class ProductCategoryUpdateValidator : AbstractValidator<ProductCategoryUpdateDto>
    {
        public ProductCategoryUpdateValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
