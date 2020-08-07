using Application.Dto.Product;
using Application.Dto.Product.Category;
using FluentValidation;

namespace CookingBook.Validators.Product.Category
{
    public class ProductCategoryUpdateValidator : AbstractValidator<ProductCategoryUpdateDto>
    {
        public ProductCategoryUpdateValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
