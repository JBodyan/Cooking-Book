using Application.Dto.Product;
using FluentValidation;

namespace CookingBook.Validators.Product
{
    public class ProductAddValidator: AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(5, 30);
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
