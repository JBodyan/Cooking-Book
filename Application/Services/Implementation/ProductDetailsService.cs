using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Dto.Product.Details;
using Application.Services.Interfaces;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementation
{
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IRepository<ProductDetails> _productDetailsRepository;
        private readonly IRepository<NutritionDeclaration> _nutritionRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContex _context;
        public ProductDetailsService(IRepository<ProductDetails> productDetailsRepository,
            IRepository<NutritionDeclaration> nutritionRepository, IMapper mapper, DatabaseContex context)
        {
            _productDetailsRepository = productDetailsRepository;
            _nutritionRepository = nutritionRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ProductDetailsDto>> GetAllProducts(Guid userId)
        {
            var products = await _productDetailsRepository.GetAll().Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<List<ProductDetailsDto>>(products);
        }

        public async Task<ProductDetailsDto> GetProductById(Expression<Func<ProductDetails, bool>> predicate)
        {
            var product = await _productDetailsRepository.GetAll()
                .SingleOrDefaultAsync(predicate);
            return product == null ? null : _mapper.Map<ProductDetailsDto>(product);
        }

        public Task UpdateProduct(ProductDetailsUpdateDto model)
        {
            //Todo
            throw new NotImplementedException();
        }

        public async Task<ProductDetailsAddDto> AddProduct(ProductDetailsAddDto model)
        {
            var product = _mapper.Map<ProductDetails>(model);
            await _productDetailsRepository.SaveChangesAsync();
            return _mapper.Map<ProductDetailsAddDto>(product);
        }

        public Task RemoveProduct(Guid id)
        {
            //Todo
            throw new NotImplementedException();
        }

        public Task<ProductDetailsDto> UpdateNutritionDeclaration(NutritionDeclarationUpdateDto model)
        {
            //Todo
            throw new NotImplementedException();
        }
    }
}
