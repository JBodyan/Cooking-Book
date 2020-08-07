using Application.Dto.Product;
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

        }
    }
}
