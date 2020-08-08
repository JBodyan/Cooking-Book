using Application.Dto.Product;
using Application.Dto.Product.Category;
using Application.Dto.Product.Details;
using AutoMapper;
using Data.Entities;

namespace Application.Configuration.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            
            CreateMap<ProductCategoryDto, Product>().ReverseMap();

            CreateMap<ProductDto, ProductCategory>().ReverseMap();

            CreateMap<ProductCategoryDto, ProductCategory>().ReverseMap();


            CreateMap<ProductUpdateDto, Product>().ReverseMap();

            CreateMap<ProductAddDto, Product>().ReverseMap();


            CreateMap<ProductCategoryAddDto, ProductCategory>().ReverseMap();

            CreateMap<ProductCategoryUpdateDto, ProductCategory>().ReverseMap();

            
            CreateMap<ProductDetailsDto, ProductDetails>().ReverseMap();

            CreateMap<ProductDetailsAddDto, ProductDetails>().ReverseMap();

            CreateMap<ProductDetailsUpdateDto, ProductDetails>().ReverseMap();

            CreateMap<NutritionDeclarationDto, NutritionDeclaration>().ReverseMap();

            CreateMap<NutritionDeclarationUpdateDto, NutritionDeclaration>().ReverseMap();

        }
    }
}
