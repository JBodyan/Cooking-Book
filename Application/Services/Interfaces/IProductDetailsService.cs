using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dto.Product.Details;
using Data.Entities;

namespace Application.Services.Interfaces
{
    public interface IProductDetailsService
    {
        Task<List<ProductDetailsDto>> GetAllProducts(Guid userId);

        Task<ProductDetailsDto> GetProductById(Expression<Func<ProductDetails, bool>> predicate);

        Task UpdateProduct(ProductDetailsUpdateDto model);

        Task<ProductDetailsAddDto> AddProduct(ProductDetailsAddDto model);

        Task RemoveProduct(Guid id);

        Task<ProductDetailsDto> UpdateNutritionDeclaration(NutritionDeclarationUpdateDto model);
    }
}
