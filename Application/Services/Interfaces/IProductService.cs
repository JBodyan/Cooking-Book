using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.Product;
using Application.Dto.Product.Category;
using Application.Dto.User;
using Data.Entities;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        #region Product

        Task<List<ProductDto>> GetAllProducts();
        
        Task<ProductDto> GetProductById(Expression<Func<Product, bool>> predicate);
        
        Task UpdateProduct(ProductUpdateDto model);
        
        Task<ProductAddDto> AddProduct(ProductAddDto model);
        
        Task RemoveProduct(Guid id);

        #endregion

        #region ProductCategory

        Task<List<ProductCategoryDto>> GetAllCategories();

        Task<ProductCategoryDto> GetCategoryById(Expression<Func<ProductCategory, bool>> predicate);

        Task UpdateCategory(ProductCategoryUpdateDto model);

        Task<ProductCategoryAddDto> AddCategory(ProductCategoryAddDto model);

        Task RemoveCategory(Guid id);

        #endregion




    }
}
