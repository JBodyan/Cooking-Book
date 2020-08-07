using Application.Dto.Product;
using FluentValidation;

namespace CookingBook.Validators.Product
{
    public class ProductCategoryAddValidator : AbstractValidator<ProductCategoryAddDto>
    {
        public ProductCategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
