using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dto.Product;
using Application.Services.Interfaces;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContex _context;
        public ProductService(IRepository<Product> productRepository,
            IRepository<ProductCategory> productCategoryRepository, IMapper mapper, DatabaseContex context)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _context = context;
        }

        #region Product

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return _mapper.Map<List<ProductDto>>(await _productRepository.GetAll().ToListAsync());
        }

        public async Task<ProductAddDto> AddProduct(ProductAddDto model)
        {
            var category = await _productCategoryRepository.GetAll()
                .Include(x => x.Products)
                .SingleOrDefaultAsync(c => c.Id == model.CategoryId);
            if (category != null)
            {
                var product = _mapper.Map<Product>(model);
                category.Products.Add(product);
                await _productCategoryRepository.SaveChangesAsync();
                return _mapper.Map<ProductAddDto>(product);
            }
            else throw new Exception($"Product with name = {model.Name} in database");
        }

        public async Task<ProductDto> GetProductById(Expression<Func<Product, bool>> predicate)
        {
            var product = await _productRepository.GetAll()
                .SingleOrDefaultAsync(predicate);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductUpdateDto model)
        {
            var newProduct = new ProductUpdateDto()
            {
                Id = model.Id,
                Name = model.Name,
                CategoryId = model.CategoryId
            };

            var product = _mapper.Map<Product>(newProduct);
            await _productRepository.UpdateAsync(product);
            var affectedRows = await _productRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
        }

        public async Task RemoveProduct(Guid id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var product = await _productRepository.FindByIdAsync(id);
            if (product == null)
            {
                throw new Exception($"There is no product with id = {id} in database");
            }

            _productRepository.Remove(product);
            var affectedRows = await _productRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
            await transaction.CommitAsync();
        }

        #endregion

        #region ProductCategory

        public async Task<List<ProductCategoryDto>> GetAllCategories()
        {
            return _mapper.Map<List<ProductCategoryDto>>(await _productCategoryRepository.GetAll().ToListAsync());
        }

        public async Task<ProductCategoryAddDto> AddCategory(ProductCategoryAddDto model)
        {
            var category = await _productCategoryRepository.FindByCondition(c => c.Name == model.Name);
            if (category == null)
            {
                category = _mapper.Map<ProductCategory>(model);
                _productCategoryRepository.Add(category);
                await _productCategoryRepository.SaveChangesAsync();
                return _mapper.Map<ProductCategoryAddDto>(category);
            }
            else throw new Exception($"Category with name = {model.Name} in database");
        }

        public async Task<ProductCategoryDto> GetCategoryById(Expression<Func<ProductCategory, bool>> predicate)
        {
            var category = await _productCategoryRepository.GetAll()
                .Include(x=>x.Products)
                .FirstOrDefaultAsync(predicate);
            return category == null ? null : _mapper.Map<ProductCategoryDto>(category);
        }

        public async Task UpdateCategory(ProductCategoryUpdateDto model)
        {
            var category = await _productCategoryRepository.FindByCondition(c => c.Id == model.Id);
            if (category == null)
            {
                throw new Exception($"There is no category with id = {model.Id} in database");
            }
            else
            {
                category.Name = model.Name;
            }
            await _productCategoryRepository.UpdateAsync(category);
            var affectedRows = await _productCategoryRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
        }

        public async Task RemoveCategory(Guid id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var category = await _productCategoryRepository.GetAll()
                .Include(x => x.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new Exception($"There is no category with id = {id} in database");
            }

            if (category.Products != null && category.Products.Count > 0)
            {
                throw new Exception($"Cant remove category {category.Name} with products inside");
            }

            _productCategoryRepository.Remove(category);
            var affectedRows = await _productCategoryRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
            await transaction.CommitAsync();
        }

        #endregion



    }
}
