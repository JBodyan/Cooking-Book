using Application.Dto.Product;
using FluentValidation;

namespace CookingBook.Validators.Product
{
    public class ProductUpdateValidator:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(5, 30);
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
