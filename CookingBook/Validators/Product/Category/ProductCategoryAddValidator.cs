using Application.Dto.Product;
using Application.Dto.Product.Category;
using FluentValidation;

namespace CookingBook.Validators.Product.Category
{
    public class ProductCategoryAddValidator : AbstractValidator<ProductCategoryAddDto>
    {
        public ProductCategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
