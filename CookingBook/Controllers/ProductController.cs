using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto.Product;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookingBook.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService ProductService { get; }
        private IUserResolverService UserResolverService { get; }

        public ProductController(IProductService productService, IUserResolverService userResolverService)
        {
            ProductService = productService;
            UserResolverService = userResolverService;
        }

        [HttpGet("all-categories")]
        [Authorize]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetCategories()
        {
            var categories = await ProductService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("get-product/{id}")]
        [Authorize]
        public async Task<ActionResult<ProductDto>> GetProductById([FromRoute]Guid id)
        {
            var product = await ProductService.GetProductById(x=>x.Id == id);
            return Ok(product);
        }

        [HttpGet("get-category/{id}")]
        [Authorize]
        public async Task<ActionResult<ProductCategoryDto>> GetCategoryById([FromRoute]Guid id)
        {
            var category = await ProductService.GetCategoryById(x => x.Id == id);
            return Ok(category);
        }

        [HttpPost("add-product")]
        [Authorize]
        public async Task<ActionResult<ProductAddDto>> AddProduct([FromBody]ProductAddDto model)
        {
            if (UserResolverService.IsUserAdmin())
            {
                var product = await ProductService.AddProduct(model);
                if (product != null) return Ok(product);
            }
            return Forbid();
        }

        [HttpPost("add-category")]
        [Authorize]
        public async Task<ActionResult<ProductCategoryAddDto>> AddCategory([FromBody]ProductCategoryAddDto model)
        {
            if (UserResolverService.IsUserAdmin())
            {
                var category = await ProductService.AddCategory(model);
                if (category != null) return Ok(category);
            }
            return Forbid();
        }

        [HttpPut("update-product")]
        [Authorize]
        public async Task<ActionResult> UpdateProduct([FromBody]ProductUpdateDto model)
        {
            try
            {
                if (UserResolverService.IsUserAdmin())
                {
                    await ProductService.UpdateProduct(model);
                    return NoContent();
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("update-category")]
        [Authorize]
        public async Task<ActionResult> UpdateCategory([FromBody]ProductCategoryUpdateDto model)
        {
            try
            {
                if (UserResolverService.IsUserAdmin())
                {
                    await ProductService.UpdateCategory(model);
                    return NoContent();
                }
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}